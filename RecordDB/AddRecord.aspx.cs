using RecordDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RecordDAL.Components;
using RecordDAL.Repositories;

namespace RecordDB
{
    public partial class AddRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divMessageArea.Visible = false;

            if (!Page.IsPostBack)
            {
                recordPanel.Visible = false;
                RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
            }
        }

        private async Task LoadDataAsync()
        {
            var artistData = new ArtistRepository();
            var artists = await artistData.GetArtistListAsync();
            artistDropDownList.DataSource = artists;
            artistDropDownList.DataTextField = "name";
            artistDropDownList.DataValueField = "ArtistId";
            artistDropDownList.DataBind();

            PopulateDropdownLists();
        }

        /// <summary>
        /// Collect the current record data.
        /// </summary>
        /// <param name="record">The current record.</param>
        private void CollectRecordData(Record record)
        {
            // this routine grabs the form data and binds it to an instance of the RecordData class 
            var rec = 0;
            var cost = 0.00M;

            // artistDropDownlist.SelectedValue = CookieData.GetCookie("aid", this);  // 
            record.ArtistId = int.Parse(artistDropDownList.SelectedValue);
            record.Name = nameTextBox.Text.Trim();
            record.Field = fieldDropDownList.SelectedValue;
            int.TryParse(recordedTextBox.Text, out rec);

            record.Recorded = rec == 0 ? 1900 : rec;

            record.Label = labelTextBox.Text.Trim();
            record.Pressing = pressingDropDownList.SelectedValue;
            record.Rating = ratingDropDownList.SelectedValue;
            var discs = 0;
            int.TryParse(discsDropDownList.SelectedValue, out discs);
            record.Discs = discs;
            record.Media = mediaDropDownList.SelectedValue;
            record.Bought = DataConvert.HtmlDateToDotNet(boughtTextBox.Text);
            decimal.TryParse(costTextBox.Text, out cost);
            record.Cost = cost;
            record.CoverName = coverNameTextBox.Text.Trim();
            record.Review = reviewTextBox.Text.Trim();
        }

        /// <summary>
        /// Clear the current record values.
        /// </summary>
        protected void ClearRecord()
        {
            artistDropDownList.SelectedValue = "0";
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
            returnValueLabel.Text = string.Empty;
        }

        /// <summary>
        /// Get the current artists record list.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void artistDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var artistId = 0;
            int.TryParse(artistDropDownList.SelectedItem.Value, out artistId);

            if (artistId > 0)
            {
                // this.ClearRecord();

                messageLabel.Text = "Artist Id: " + artistId;
                recordPanel.Visible = true;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(SubmitAsync));
        }

        private async Task SubmitAsync()
        {
            var record = new Record();
            var showMessage = false;

            if (artistDropDownList.SelectedIndex > 0)
            {
                var recordData = new RecordRepository();

                CollectRecordData(record);

                messageLabel.Text = record.Name + "<br/>";

                if (!string.IsNullOrEmpty(record.Name))
                {
                    var recordId = await recordData.InsertAsync(record);

                    if (recordId > 0)
                    {
                        // var rec = await recordData.SelectAsync(recordId);
                        messageLabel.Text += record.Review;
                        showMessage = true;
                    }
                    else
                    {
                        showMessage = true;
                        messageLabel.Text += "<font color=\"Red\">ERROR: Record was not added!</font>";
                    }
                }
                else
                {
                    showMessage = true;
                    messageLabel.Text += "<font color=\"Red\">ERROR: Record was not added!</font>";
                }
            }
            else
            {
                showMessage = true;
                messageLabel.Text += "Please select an Artist!";
            }

            if (showMessage)
            {
                divMessageArea.Visible = true;
            }
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default");
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
    }
}