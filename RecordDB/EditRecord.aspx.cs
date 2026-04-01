using RecordDAL.Components;
using RecordDAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RecordDAL.Repositories;

namespace RecordDB
{
    public partial class EditRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
            }
        }

        private async Task LoadDataAsync()
        {
            // var dtnow = DateTime.Now;
            // dateLabel.Text = dtnow.ToLongDateString();
            var recordId = 0;
            var artistId = 0;
            var ridString = string.Empty;
            browseButton.Visible = false;

            // Check for a specific record id to display
            if (Page.RouteData.Values["rid"] != null)
            {
                ridString = Page.RouteData.Values["rid"].ToString();
                var rid = 0;
                int.TryParse(Page.RouteData.Values["rid"].ToString(), out rid);
                recordId = rid;
            }
            else
            {
                recordId = 0;
            }

            var artistData = new ArtistRepository();
            if (recordId > 0)
            {
                artistId = await artistData.GetArtistIdAsync(recordId);
                // use this to return to the browse page
                artistLabel.Text = artistId.ToString(CultureInfo.InvariantCulture);
            }


            messageLabel.Text = string.Empty;
            messageAreaDiv.Visible = false;

            if (!Page.IsPostBack)
            {
                var artists = await artistData.GetArtistListAsync();
                artistDropDownList.DataSource = artists;
                artistDropDownList.DataTextField = "name";
                artistDropDownList.DataValueField = "ArtistId";
                artistDropDownList.DataBind();

                PopulateDropdownLists();

                // populate a record form from the recordView page.
                if (recordId > 0 && artistId > 0)
                {
                    artistDropDownList.SelectedValue = artistId.ToString(CultureInfo.InvariantCulture);

                    var recordData = new RecordRepository();
                    var recordList = await recordData.SelectArtistRecordsAsync(artistId);
                    recordDropDownList.DataSource = recordList;
                    recordDropDownList.DataTextField = "name";
                    recordDropDownList.DataValueField = "RecordId";
                    recordDropDownList.DataBind();

                    recordDropDownList.SelectedValue = recordId.ToString(CultureInfo.InvariantCulture);
                    await this.PopulateRecordFormAsync(recordId);
                    browseButton.Visible = true;
                }
                else
                {
                    recordDropDownPanel.Visible = false;
                    tablePanel.Visible = false;
                }
            }
            //else
            //{
            //    tablePanel.Visible = false;
            //}
        }

        protected void artistDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ArtistSelectedIndexChangedAsync));
        }

        /// <summary>
        /// Get the current artists record list.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected async Task ArtistSelectedIndexChangedAsync()
        {
            var artistId = 0;
            int.TryParse(artistDropDownList.SelectedItem.Value, out artistId);

            if (artistId > 0)
            {
                artistLabel.Text = artistId.ToString(CultureInfo.InvariantCulture);
                browseButton.Visible = true;
                // now we have to get an artists records
                var recordData = new RecordRepository();
                var recordList = await recordData.SelectArtistRecordsAsync(artistId);
                recordDropDownList.DataSource = recordList;
                recordDropDownList.DataTextField = "name";
                recordDropDownList.DataValueField = "RecordId";
                recordDropDownList.DataBind();

                this.ClearRecord();
                recordDropDownPanel.Visible = true;
                tablePanel.Visible = false;
            }
        }

        protected void recordDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(RecordSelectedIndexChangedAsync));
        }

        /// <summary>
        /// Edit the currently selected record.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected async Task RecordSelectedIndexChangedAsync()
        {
            // now we have an record to edit
            var recordId = 0;
            browseButton.Visible = true;
            int.TryParse(recordDropDownList.SelectedItem.Value, out recordId);

            if (recordId > 0)
            {
                browseButton.Visible = true;
                await this.PopulateRecordFormAsync(recordId);
            }
        }

        /// <summary>
        /// Populate the record form.
        /// </summary>
        /// <param name="recordId">The record id.</param>
        private async Task PopulateRecordFormAsync(int recordId)
        {
            var recordData = new RecordRepository();
            var record = await recordData.SelectAsync(recordId);

            nameTextBox.Text = record.Name;
            fieldDropDownList.SelectedValue = record.Field;
            recordedTextBox.Text = record.Recorded.ToString(CultureInfo.InvariantCulture);
            labelTextBox.Text = record.Label;
            pressingDropDownList.SelectedValue = record.Pressing;
            ratingDropDownList.SelectedValue = record.Rating;
            discsDropDownList.SelectedValue = record.Discs.ToString(CultureInfo.InvariantCulture);
            mediaDropDownList.SelectedValue = record.Media;

            boughtTextBox.Text = record.Bought.ToShortDateString();

            if (boughtTextBox.Text == "1/01/0001")
            {
                boughtTextBox.Text = "1/01/1900";
            }

            costTextBox.Text = record.Cost.ToString("F", CultureInfo.InvariantCulture);
            coverNameTextBox.Text = record.CoverName;
            reviewTextBox.Text = record.Review;

            messageLabel.Text = string.Empty;
            tablePanel.Visible = true;
        }

        /// <summary>
        /// Clear the record data.
        /// </summary>
        private void ClearRecord()
        {
            nameTextBox.Text = string.Empty;
            fieldDropDownList.SelectedValue = "Acoustic";
            recordedTextBox.Text = string.Empty;
            labelTextBox.Text = string.Empty;
            pressingDropDownList.SelectedValue = "Am";
            ratingDropDownList.SelectedValue = "*";
            discsDropDownList.SelectedValue = "1";
            mediaDropDownList.SelectedValue = "CD";
            boughtTextBox.Text = string.Empty;
            costTextBox.Text = string.Empty;
            coverNameTextBox.Text = string.Empty;
            reviewTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Populate the dropdown lists.
        /// </summary>
        private void PopulateDropdownLists()
        {
            // I have to set up the dropdown lists here
            fieldDropDownList.Items.Add("Acoustic");
            fieldDropDownList.Items.Add("Audio");
            fieldDropDownList.Items.Add("Blues");
            fieldDropDownList.Items.Add("Classical");
            fieldDropDownList.Items.Add("Comedy");
            fieldDropDownList.Items.Add("Country");
            fieldDropDownList.Items.Add("Folk");
            fieldDropDownList.Items.Add("Fusion");
            fieldDropDownList.Items.Add("Jazz");
            fieldDropDownList.Items.Add("Pop");
            fieldDropDownList.Items.Add("Rock");
            fieldDropDownList.Items.Add("Soul");
            fieldDropDownList.Items.Add("Soundtrack");
            fieldDropDownList.Items.Add("World");

            pressingDropDownList.Items.Add("Am");
            pressingDropDownList.Items.Add("Aus");
            pressingDropDownList.Items.Add("Can");
            pressingDropDownList.Items.Add("Eng");
            pressingDropDownList.Items.Add("Fra");
            pressingDropDownList.Items.Add("Ger");
            pressingDropDownList.Items.Add("Hk");
            pressingDropDownList.Items.Add("Hol");
            pressingDropDownList.Items.Add("Ita");
            pressingDropDownList.Items.Add("Jap");
            pressingDropDownList.Items.Add("Kor");
            pressingDropDownList.Items.Add("Swe");
            pressingDropDownList.Items.Add("Swi");

            ratingDropDownList.Items.Add("*");
            ratingDropDownList.Items.Add("**");
            ratingDropDownList.Items.Add("***");
            ratingDropDownList.Items.Add("****");

            discsDropDownList.Items.Add("1");
            discsDropDownList.Items.Add("2");
            discsDropDownList.Items.Add("3");
            discsDropDownList.Items.Add("4");
            discsDropDownList.Items.Add("5");
            discsDropDownList.Items.Add("6");

            mediaDropDownList.Items.Add("CD");
            mediaDropDownList.Items.Add("R");
            mediaDropDownList.Items.Add("DVD");
            mediaDropDownList.Items.Add("CD/DVD");
            mediaDropDownList.Items.Add("Blu-ray");
            mediaDropDownList.Items.Add("CD/Blu-ray");
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(SubmitAsync));
        }

        private async Task SubmitAsync()
        {
            var record = new Record();
            var recordData = new RecordRepository();

            record.RecordId = int.Parse(recordDropDownList.SelectedItem.Value);
            record.ArtistId = int.Parse(artistDropDownList.SelectedItem.Value);
            record.Name = nameTextBox.Text;
            record.Field = fieldDropDownList.SelectedItem.Value;

            var recorded = 0;
            int.TryParse(recordedTextBox.Text, out recorded);

            if (recorded == 0)
            {
                record.Recorded = 1900;
            }

            record.Recorded = recorded;
            record.Label = labelTextBox.Text;
            record.Pressing = pressingDropDownList.SelectedItem.Value;
            record.Rating = ratingDropDownList.SelectedItem.Value;
            record.Discs = int.Parse(discsDropDownList.SelectedItem.Value);
            record.Media = mediaDropDownList.SelectedItem.Value;
            record.Bought = DataConvert.HtmlDateToDotNet(boughtTextBox.Text);
            record.Cost = Convert.ToDecimal(costTextBox.Text);
            record.CoverName = coverNameTextBox.Text;
            record.Review = reviewTextBox.Text;

            var recordId = 0;

            recordId = await recordData.UpdateAsync(
                record.RecordId,
                record.ArtistId,
                record.Name,
                record.Field,
                record.Recorded,
                record.Label,
                record.Pressing,
                record.Rating,
                record.Discs,
                record.Media,
                record.Bought,
                record.Cost,
                record.CoverName,
                record.Review);

            if (recordId == 0)
            {
                messageLabel.Text += "<font color=\"Red\">ERROR: Record was not added!</font><br/>";
            }
            else
            {
                messageLabel.Text = "Record ID: " + record.RecordId.ToString(CultureInfo.InvariantCulture) + "<br/>";
                messageLabel.Text += record.Review;
            }

            messageAreaDiv.Visible = true;
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default");
        }

        protected void browseButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/GetArtist/aid" + artistLabel.Text);
        }
    }
}