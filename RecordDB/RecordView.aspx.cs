using RecordDAL.Data;
using RecordDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RecordDAL.Models;

namespace RecordDB
{
    public partial class RecordView : System.Web.UI.Page
    {
        /// <summary>
        /// Gets or sets the recordId.
        /// </summary>
        protected int Rid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var dtnow = DateTime.Now;
            var ridString = string.Empty;
            dateLabel.Text = dtnow.ToLongDateString();

            // Check for a specific record id to display
            if (Page.RouteData.Values["rid"] != null)
            {
                ridString = Page.RouteData.Values["rid"].ToString();
                var recordId = 0;
                int.TryParse(Page.RouteData.Values["rid"].ToString(), out recordId);
                Rid = recordId;

            }
            else
            {
                Rid = 1;
            }
        }

        /// <summary>
        /// The edit button_ click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        protected void editButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../UpdateRecord/" + this.Rid);
        }

        /// <summary>
        /// The home button_ click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default");
        }

        protected string ShowBiography()
        {
            var biography = RepositoryInitialiser.ArtistRepo.GetBiography(Rid);

            return biography;
        }
    }
}