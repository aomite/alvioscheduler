using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlvioScheduler.Model
{
    public class Country
    {
        public int countryId { get; set; }

        public string country { get; set; }

        public string createDate { get; set; }

        public string createdBy { get; set; }

        public string lastUpdate { get; set; }

        public string lastUpdateBy { get; set; }
    }
}
