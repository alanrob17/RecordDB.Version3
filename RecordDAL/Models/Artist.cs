using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDAL.Models
{
    public class Artist
    {
        #region " Properties "

        public int ArtistId { get; set; } // identity field

        public string FirstName { get; set; }

        public string LastName { get; set; } // not null

        public string Name { get; set; }

        public string Biography { get; set; }

        public override string ToString()
        {
            return $"{ArtistId}: {Name} -- {LastName}, {FirstName}\n{Biography}\n";
        }

        #endregion
    }
}
