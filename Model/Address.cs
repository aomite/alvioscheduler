using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlvioScheduler.Model
{
    public class Address
    {
        public int addressId { get; set; }

        public string address { get; set; }

        public string address2 { get; set; }

        public int cityId { get; set; }

        public string postalCode { get; set; }

        public string phone { get; set; }

        public string createDate { get; set; }

        public string createdBy { get; set; }

        public string lastUpdate { get; set; }

        public string lastUpdateBy { get; set; }
    }
}
