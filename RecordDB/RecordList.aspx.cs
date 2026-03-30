using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RecordDAL.Models;
using RecordDAL.Repositories;

namespace RecordDB
{
    public partial class RecordList : System.Web.UI.Page
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
            var dtnow = DateTime.Now;
            dateLabel.Text = dtnow.ToLongDateString();

            //// Show all records
            var recordList = await RepositoryInitialiser.RecordRepo.SelectAsync();
            var artistList = await RepositoryInitialiser.ArtistRepo.SelectAsync();

            var sb = new StringBuilder();

            var q = from a in artistList
                orderby a.LastName, a.FirstName
                select a;

            foreach (var artist in q)
            {
                sb.Append("<p><br/><strong><a href=\"GetArtist/aid" + artist.ArtistId + "\">" + artist.Name + "</a></strong></p>");

                var ar = from r in recordList
                    where artist.ArtistId == r.ArtistId
                    orderby r.Recorded
                    select r;

                foreach (var rec in ar)
                {
                    // RecordView.aspx?rid=12
                    sb.Append("<p>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"GetRecord/" + rec.RecordId + "\">" + rec.Recorded + " - " + rec.Name + " - (" + rec.Media + ")</a></p>");
                }
            }

            recordLiteral.Text = sb.ToString();
        }
    }
}