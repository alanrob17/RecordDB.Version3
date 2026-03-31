using RecordDAL.Components;
using RecordDAL.Data;
using RecordDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDAL.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly IDataAccess _db;

        public StatisticRepository(IDataAccess db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        #region " Methods "

        public async Task<Statistic> GetStatisticsAsync()
        {
            var statistics = new Statistic();

            // query for total number of CD's
            var squery = "select sum(discs) from record where media = 'CD'";
            var result = await _db.GetCountOrIdQ(squery, new { });
            statistics.TotalCDs = (int?)result ?? 0;

            // query for total number of records
            squery = "select sum(discs) from record where media='R'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.TotalRecords = (int?)result ?? 0;
            
            // query for number of Folk Records
            squery = "select sum(discs) from record where field = 'Rock'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.RockDisks = (int?)result ?? 0;

            // query for number of Rock Records
            squery = "select sum(discs) from record where field = 'Folk'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.FolkDisks = (int?)result ?? 0;

            // query for number of Acoustic Records
            squery = "select sum(discs) from record where field = 'Acoustic'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.AcousticDisks = (int?)result ?? 0;

            // query for number of Jazz and Fusion Records
            squery = "select sum(discs) from record where field = 'Jazz' or field = 'Fusion'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.JazzDisks = (int?)result ?? 0;

            // query for number of Blues Records
            squery = "select sum(discs) from record where field = 'Blues'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.BluesDisks = (int?)result ?? 0;

            // query for number of Country Records
            squery = "select sum(discs) from record where field = 'Country'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.CountryDisks = (int?)result ?? 0;

            // query for number of Classical Records
            squery = "select sum(discs) from record where field = 'Classical'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.ClassicalDisks = (int?)result ?? 0;

            // query for number of Soundtrack Records
            squery = "select sum(discs) from record where field = 'Soundtrack'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.SoundtrackDisks = (int?)result ?? 0;

            // query for number of Four Star Records
            squery = "select count(*) from record where Rating = '****'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.FourStarDisks = (int?)result ?? 0;

            // query for number of Three Star Records
            squery = "select count(*) from record where Rating = '***'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.ThreeStarDisks = (int?)result ?? 0;

            // query for number of Two Star Records
            squery = "select count(*) from record where Rating = '**'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.TwoStarDisks = (int?)result ?? 0;

            // query for number of One Star Records
            squery = "select count(*) from record where Rating = '*'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.OneStarDisks = (int?)result ?? 0;

            // query for amount spent on records
            squery = "select sum(cost) from record where media = 'R'";
            var cost = await _db.GetCostQ(squery, new { });
            statistics.RecordCost = cost;

            // query for amount spent on CD's
            squery = "select sum(cost) from record where media = 'CD'";
            cost = await _db.GetCostQ(squery, new { });
            statistics.CDCost = cost;

            // calculate the average cost of all CDs
            statistics.AvCDCost = statistics.CDCost / (decimal)statistics.TotalCDs;

            // query for amount spent on records and CD's
            squery = "select sum(cost) from record";
            cost = await _db.GetCostQ(squery, new { });
            statistics.TotalCost = cost;

            // query for Number of CD's bought in 2017
            squery = "select sum(discs) from record where bought > '31-Dec-2016' and bought < '01-Jan-2018'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.Disks2017 = (int?)result ?? 0;

            // query for amount spent on CD's in 2017
            squery = "select sum(cost) from record where bought > '31-Dec-2016' and bought < '01-Jan-2018'";
            cost = await _db.GetCostQ(squery, new { });
            statistics.Cost2017 = cost;

            // this is to stop a divide by zero error if nothing has been bought
            if (statistics.Cost2017 > 1)
            {
                statistics.Av2017 = statistics.Cost2017 / (decimal)statistics.Disks2017;
            }
            else
            {
                statistics.Cost2017 = 0.00m;
                statistics.Av2017 = 0.00m;
            }

            // query for Number of CD's bought in 2018
            squery = "select sum(discs) from record where bought > '31-Dec-2017' and bought < '01-Jan-2019'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.Disks2018 = (int?)result ?? 0;

            // query for amount spent on CD's in 2018
            squery = "select sum(cost) from record where bought > '31-Dec-2017' and bought < '01-Jan-2019'";
            cost = await _db.GetCostQ(squery, new { });
            statistics.Cost2018 = cost;

            // this is to stop a divide by zero error if nothing has been bought
            if (statistics.Cost2018 > 1)
            {
                statistics.Av2018 = statistics.Cost2018 / (decimal)statistics.Disks2018;
            }
            else
            {
                statistics.Cost2018 = 0.00m;
                statistics.Av2018 = 0.00m;
            }

            // query for Number of CD's bought in 2019
            squery = "select sum(discs) from record where bought > '31-Dec-2018' and bought < '01-Jan-2020'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.Disks2019 = (int?)result ?? 0;

            // query for amount spent on CD's in 2019
            squery = "select sum(cost) from record where bought > '31-Dec-2018' and bought < '01-Jan-2020'";
            cost = await _db.GetCostQ(squery, new { });
            statistics.Cost2019 = cost;

            // this is to stop a divide by zero error if nothing has been bought
            if (statistics.Cost2019 > 1)
            {
                statistics.Av2019 = statistics.Cost2019 / (decimal)statistics.Disks2019;
            }
            else
            {
                statistics.Cost2019 = 0.00m;
                statistics.Av2019 = 0.00m;
            }

            // query for Number of CD's bought in 2020
            squery = "select sum(discs) from record where bought > '31-Dec-2019' and bought < '01-Jan-2021'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.Disks2020 = (int?)result ?? 0;

            // query for amount spent on CD's in 2020
            squery = "select sum(cost) from record where bought > '31-Dec-2019' and bought < '01-Jan-2021'";
            cost = await _db.GetCostQ(squery, new { });
            statistics.Cost2020 = cost;

            // this is to stop a divide by zero error if nothing has been bought
            if (statistics.Cost2020 > 1)
            {
                statistics.Av2020 = statistics.Cost2020 / (decimal)statistics.Disks2020;
            }
            else
            {
                statistics.Cost2020 = 0.00m;
                statistics.Av2020 = 0.00m;
            }

            // query for Number of CD's bought in 2021
            squery = "select sum(discs) from record where bought > '31-Dec-2020' and bought < '01-Jan-2022'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.Disks2021 = (int?)result ?? 0;

            // query for amount spent on CD's in 2021
            squery = "select sum(cost) from record where bought > '31-Dec-2020' and bought < '01-Jan-2022'";
            cost = await _db.GetCostQ(squery, new { });
            statistics.Cost2021 = cost;

            // this is to stop a divide by zero error if nothing has been bought
            if (statistics.Cost2021 > 1)
            {
                statistics.Av2021 = statistics.Cost2021 / (decimal)statistics.Disks2021;
            }
            else
            {
                statistics.Cost2021 = 0.00m;
                statistics.Av2021 = 0.00m;
            }

            // query for Number of CD's bought in 2022
            squery = "select sum(discs) from record where bought > '31-Dec-2021' and bought < '01-Jan-2023'";
            result = await _db.GetCountOrIdQ(squery, new { });
            statistics.Disks2022 = (int?)result ?? 0;

            // query for amount spent on CD's in 2022
            squery = "select sum(cost) from record where bought > '31-Dec-2021' and bought < '01-Jan-2023'";
            cost = await _db.GetCostQ(squery, new { });
            statistics.Cost2022 = cost;

            // this is to stop a divide by zero error if nothing has been bought
            if (statistics.Cost2022 > 1)
            {
                statistics.Av2022 = statistics.Cost2022 / (decimal)statistics.Disks2022;
            }
            else
            {
                statistics.Cost2022 = 0.00m;
                statistics.Av2022 = 0.00m;
            }

            return statistics;
        }

        #endregion
    }
}
