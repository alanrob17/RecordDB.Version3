using RecordDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordDB
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dtnow = DateTime.Now;
            dateLabel.Text = dtnow.ToLongDateString();

            if (!Page.IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
            }
        }

        private async Task LoadDataAsync()
        {
            var statistics = await RepositoryInitialiser.StatisticRepo.GetStatisticsAsync();

            disks2022Label.Text = statistics.Disks2022.ToString(CultureInfo.InvariantCulture);
            cost2022Label.Text = statistics.Cost2022.ToString("C");
            av2022Label.Text = statistics.Av2022.ToString("C");
            disks2021Label.Text = statistics.Disks2021.ToString(CultureInfo.InvariantCulture);
            cost2021Label.Text = statistics.Cost2021.ToString("C");
            av2021Label.Text = statistics.Av2021.ToString("C");
            disks2020Label.Text = statistics.Disks2020.ToString(CultureInfo.InvariantCulture);
            cost2020Label.Text = statistics.Cost2020.ToString("C");
            av2020Label.Text = statistics.Av2020.ToString("C");
            disks2019Label.Text = statistics.Disks2019.ToString(CultureInfo.InvariantCulture);
            cost2019Label.Text = statistics.Cost2019.ToString("C");
            av2019Label.Text = statistics.Av2019.ToString("C");
            disks2018Label.Text = statistics.Disks2018.ToString(CultureInfo.InvariantCulture);
            cost2018Label.Text = statistics.Cost2018.ToString("C");
            av2018Label.Text = statistics.Av2018.ToString("C");
            disks2017Label.Text = statistics.Disks2017.ToString(CultureInfo.InvariantCulture);
            cost2017Label.Text = statistics.Cost2017.ToString("C");
            av2017Label.Text = statistics.Av2017.ToString("C");
            totalCDsLabel.Text = statistics.TotalCDs.ToString(CultureInfo.InvariantCulture);
            cDCostLabel.Text = statistics.CDCost.ToString("C");
            avCDCostLabel.Text = statistics.AvCDCost.ToString("C");
            totalRecordsLabel.Text = statistics.TotalRecords.ToString(CultureInfo.InvariantCulture);
            recordCostLabel.Text = statistics.RecordCost.ToString("C");
            totalCostLabel.Text = statistics.TotalCost.ToString("C");
            rockDisksLabel.Text = statistics.RockDisks.ToString(CultureInfo.InvariantCulture);
            folkDisksLabel.Text = statistics.FolkDisks.ToString(CultureInfo.InvariantCulture);
            acousticDisksLabel.Text = statistics.AcousticDisks.ToString(CultureInfo.InvariantCulture);
            jazzDisksLabel.Text = statistics.JazzDisks.ToString(CultureInfo.InvariantCulture);
            bluesDisksLabel.Text = statistics.BluesDisks.ToString(CultureInfo.InvariantCulture);
            countryDisksLabel.Text = statistics.CountryDisks.ToString(CultureInfo.InvariantCulture);
            classicalDisksLabel.Text = statistics.ClassicalDisks.ToString(CultureInfo.InvariantCulture);
            soundtrackDisksLabel.Text = statistics.SoundtrackDisks.ToString(CultureInfo.InvariantCulture);
            fourStarDisksLabel.Text = statistics.FourStarDisks.ToString(CultureInfo.InvariantCulture);
            threeStarDisksLabel.Text = statistics.ThreeStarDisks.ToString(CultureInfo.InvariantCulture);
            twoStarDisksLabel.Text = statistics.TwoStarDisks.ToString(CultureInfo.InvariantCulture);
            oneStarDisksLabel.Text = statistics.OneStarDisks.ToString(CultureInfo.InvariantCulture);
        }
    }
}