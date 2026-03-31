using RecordDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDAL.Repositories
{
    public interface IStatisticRepository
    {
        Task<Statistic> GetStatisticsAsync();
    }
}
