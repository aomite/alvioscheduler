using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlvioScheduler.model
{
    public class CustomerDetailedView
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int AddressId { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string Zipcode { get; set; }

        public string PhoneNum { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }


    }
}
