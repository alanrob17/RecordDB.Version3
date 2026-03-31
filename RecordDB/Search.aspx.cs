using RecordDAL.Models;
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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dtnow = DateTime.Now;
            dateLabel.Text = dtnow.ToLongDateString();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(SearchAsync));
        }

        protected async Task SearchAsync()
        {
            var artist = new Artist
            {
                FirstName = this.firstNameTextBox.Text.Trim(),
                LastName = this.lastNameTextBox.Text.Trim()
            };

            // Show the message area
            divMessageArea.Visible = true;

            if (string.IsNullOrEmpty(artist.LastName))
            {
                messageLabel.Text = "You must enter a Last name!";
            }
            else
            {
                var artistId = 0;

                var artistData = new ArtistRepository();

                artistId = string.IsNullOrEmpty(artist.FirstName) ? await artistData.GetArtistIdAsync(string.Empty, artist.LastName) : await artistData.GetArtistIdAsync(artist.FirstName, artist.LastName);

                if (artistId > 0)
                {
                    Response.Redirect("GetArtist/aid" + artistId);
                }
                else
                {
                    messageLabel.Text = "Name wasn't found!";
                }
            }
        }
    }
}