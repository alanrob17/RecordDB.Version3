using RecordDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordDB
{
    public partial class EditArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divMessageArea.Visible = false;

            if (!Page.IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
            }
        }

        private async Task LoadDataAsync()
        {
            // var dtnow = DateTime.Now;
            // dateLabel.Text = dtnow.ToLongDateString();

            editPanel.Visible = false;

            var artistData = new RecordDAL.Repositories.ArtistRepository();
            var artists = await artistData.GetArtistListAsync();
            artistDropDownList.DataSource = artists;
            artistDropDownList.DataTextField = "name";
            artistDropDownList.DataValueField = "ArtistId";
            artistDropDownList.DataBind();
        }

        protected void artistDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(SelectedIndexChangedAsync));
        }

        private async Task SelectedIndexChangedAsync()
        {
            // now we have an artist to edit
            var artistId = int.Parse(artistDropDownList.SelectedItem.Value);

            if (artistId > 0)
            {
                editPanel.Visible = true;
                var artistData = new RecordDAL.Repositories.ArtistRepository();

                var artist = await artistData.SelectAsync(int.Parse(artistDropDownList.SelectedItem.Value));

                firstNameTextBox.Text = artist.FirstName;
                lastNameTextBox.Text = artist.LastName;
                nameTextBox.Text = artist.Name;
                biographyTextBox.Text = artist.Biography;
            }
            else
            {
                editPanel.Visible = false;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(SubmitAsync));
        }

        private async Task SubmitAsync()
        {
            var artistData = new RecordDAL.Repositories.ArtistRepository();
            var artist = new Artist
            {
                // set member properties
                ArtistId = Convert.ToInt32(artistDropDownList.SelectedItem.Value),
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Name = nameTextBox.Text,
                Biography = biographyTextBox.Text
            };

            var artistId = await artistData.UpdateArtistAsync(artist);

            divMessageArea.Visible = true;

            // Show the new artist id
            if (artistId == 0)
            {
                messageLabel.Text = "ERROR: Artist was not added! " + artistId;
            }
            else
            {
                messageLabel.Text = "Artist Id: " + artistId + "<br/>";
                messageLabel.Text += "<strong>" + artist.Biography + "</strong>";
            }
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }
    }
}