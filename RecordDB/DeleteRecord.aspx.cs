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
    public partial class DeleteRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            recordDropDownPanel.Visible = false;

            if (!Page.IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
            }
        }

        private async Task LoadDataAsync()
        {
            tablePanel.Visible = false;

            var artistData = new ArtistRepository();
            var artists = await artistData.GetArtistListAsync();
            artistDropDownList.DataSource = artists;
            artistDropDownList.DataTextField = "name";
            artistDropDownList.DataValueField = "ArtistId";
            artistDropDownList.DataBind();
        }

        protected void artistDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ArtistSelectedIndexChangedAsync));
        }

        protected async Task ArtistSelectedIndexChangedAsync()
        {
            var artistId = 0;
            int.TryParse(artistDropDownList.SelectedItem.Value, out artistId);

            if (artistId > 0)
            {
                // now we have to get an artists records
                var recordData = new RecordRepository();
                var recordList = await recordData.SelectArtistRecordsAsync(artistId);
                recordDropDownList.DataSource = recordList;
                recordDropDownList.DataTextField = "name";
                recordDropDownList.DataValueField = "RecordId";
                recordDropDownList.DataBind();

                recordDropDownPanel.Visible = true;
            }
        }

        protected void recordDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(RecordSelectedIndexChangedAsync));
        }

        protected async Task RecordSelectedIndexChangedAsync()
        {
            // now we have an record to edit
            var recordId = 0;

            int.TryParse(recordDropDownList.SelectedItem.Value, out recordId);

            if (recordId > 0)
            {
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

            nameLabel.Text = record.Name;
            fieldLabel.Text = record.Field;
            recordedLabel.Text = record.Recorded.ToString(CultureInfo.InvariantCulture);
            recordLabel.Text = record.Label;
            pressingLabel.Text = record.Pressing;
            ratingLabel.Text = record.Rating;
            discsLabel.Text = record.Discs.ToString(CultureInfo.InvariantCulture);
            mediaLabel.Text = record.Media;

            boughtLabel.Text = record.Bought.ToShortDateString();

            costLabel.Text = record.Cost.ToString("F", CultureInfo.InvariantCulture);
            coverNameLabel.Text = record.CoverName;
            reviewLabel.Text = record.Review;

            messageLabel.Text = string.Empty;
            tablePanel.Visible = true;
        }

        protected void deleteButton_ItemDeleted(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ItemDeletedAsync));
        }

        private async Task ItemDeletedAsync()
        {
            var recordData = new RecordRepository();
            var recordId = int.Parse(recordDropDownList.SelectedItem.Value);

            if (recordId > 0)
            {
                await recordData.DeleteAsync(recordId);
            }
            else
            {
                messageAreaDiv.Visible = true;
                messageLabel.Text = "No record to delete!";
            }

            Response.Redirect("Default");
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            //var recordData = new ArtistData();
            //var artistId = recordData.(int.Parse(recordDropDownList.SelectedItem.Value));

            //if (artistId > 0)
            //{
            //    artistData.Delete(artistId);
            //}
            //else
            //{
            //    divMessageArea.Visible = true;
            //    messageLabel.Text = "No artist to delete!";
            //}

            //Response.Redirect("Default");

        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}