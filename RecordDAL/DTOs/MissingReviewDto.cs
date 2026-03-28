using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecordDAL.DTOs
{
    public class MissingReviewDto
    {
        public int RecordId { get; set; }
        public string Name { get; set; }
        public string Record { get; set; }
    }
}
