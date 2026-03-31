using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordDB
{
    public partial class Recorded : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dtnow = DateTime.Now;
            dateLabel.Text = dtnow.ToLongDateString();
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(yearTextBox.Text))
            {
                Response.Redirect("GetArtist/r" + yearTextBox.Text);
            }
            else
            {
                messageLabel.Text = "Please enter a Year value!";
                messageAreaDiv.Visible = true;
            }
        }
    }
}