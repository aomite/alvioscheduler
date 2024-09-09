﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlvioScheduler.model
{
    public class Customer
    {
        public int customerId { get; set; }

        public string customerName { get; set; }

        public int addressId { get; set; }

        public int active { get; set; }

        public string createDate { get; set; }

        public string createdBy { get; set; }

        public string lastUpdate { get; set; }

        public string lastUpdateBy { get; set; }
    }
}
