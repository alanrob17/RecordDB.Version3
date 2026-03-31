using RecordDAL.Components;
using RecordDAL.Data;
using RecordDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDAL.Repositories
{
    public class TotalRepository : ITotalRepository
    {
        private readonly IDataAccess _db;

        // Parameterless ctor required by ObjectDataSource
        public TotalRepository() : this(new DataAccess()) { }

        public TotalRepository(IDataAccess db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Total> GetTotalCosts()
        {
            var sproc = "sp_getTotalsForEachArtist";

            IEnumerable<Total> totals = _db.GetBrowseData<Total, dynamic>(sproc, new { });

            return totals.ToList();
        }
    }
}
