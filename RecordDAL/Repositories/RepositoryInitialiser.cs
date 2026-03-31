using RecordDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDAL.Repositories
{
    public static class RepositoryInitialiser
    {
        public static readonly ArtistRepository ArtistRepo;
        public static readonly RecordRepository RecordRepo;
        public static readonly StatisticRepository StatisticRepo;

        static RepositoryInitialiser()
        {
            var db = new DataAccess();
            ArtistRepo = new ArtistRepository(db);
            RecordRepo = new RecordRepository(db);
            StatisticRepo = new StatisticRepository(db);
        }
    }
}
