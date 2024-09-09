using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlvioScheduler.Model
{
    public class AppointmentLimitedView
    {
        public int AppointmentId { get; set; }

        public DateTime Date { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
        
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }
        
        public string Type { get; set; }
    }
}
