using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesErrorDashboard.Models
{
    public class LogModel
    {
       
        public string queueName { get; set; }
        public string TransactionId { get; set; }
        public string message { get; set; }
        public string robotName { get; set; }
        public string processName { get; set; }
        public string timeStamp { get; set; }
        public string fileName { get; set; }
       
    }
}
