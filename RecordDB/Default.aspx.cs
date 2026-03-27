using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RecordDAL.Data;
using RecordDAL.Repositories;

namespace RecordDB
{
    public partial class _Default : Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
            }

        }

        private async Task LoadDataAsync()
        {
            var db = new DataAccess();
            var repo = new ArtistRepository(db);
            var artists = await repo.GetArtists();

            foreach (var artist in artists)
            {
                messageLabel.Text += $"<p>{artist.Name}</p>";    
            }
        }
    }
}