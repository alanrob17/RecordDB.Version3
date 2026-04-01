using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RecordDAL.Repositories;

namespace RecordDB
{
    public partial class DeleteArtist : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                editPanel.Visible = false;

                var artistData = new ArtistRepository();
                var artists = await artistData.GetArtistListAsync();
                artistDropDownList.DataSource = artists;
                artistDropDownList.DataTextField = "name";
                artistDropDownList.DataValueField = "ArtistId";
                artistDropDownList.DataBind();
            }
        }

        protected void artistDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ArtistSelectedIndexChangedAsync));
        }

        protected async Task ArtistSelectedIndexChangedAsync()
        {
            // now we have an artist to edit
            var artistId = int.Parse(artistDropDownList.SelectedItem.Value);

            if (artistId > 0)
            {
                editPanel.Visible = true;
                var artistData = new ArtistRepository();

                var artist = await artistData.SelectAsync(artistId);

                firstNameLabel.Text = artist.FirstName;
                lastNameLabel.Text = artist.LastName;
                nameLabel.Text = artist.Name;
                biographyLabel.Text = artist.Biography;
            }
            else
            {
                editPanel.Visible = false;
            }
        }

        protected void deleteButton_ItemDeleted(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ItemDeletedAsync));
        }

        private async Task ItemDeletedAsync()
        {
            var artistData = new ArtistRepository();
            var artistId = int.Parse(artistDropDownList.SelectedItem.Value);

            if (artistId > 0)
            {
                await artistData.DeleteAsync(artistId);
            }
            else
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "No artist to delete!";
            }

            Response.Redirect("Default");
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }
    }
}