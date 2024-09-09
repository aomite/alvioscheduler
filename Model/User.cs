using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlvioScheduler.model
{
    public class User
    {
        public int userId { get; set; }

        public string userName { get; set; }

        public string password { get; set; }

        public int active { get; set; }

        public string createDate { get; set; }

        public string createdBy { get; set; }

        public string lastUpdate { get; set; }

        public string lastUpdateBy { get; set; }
    }
}
