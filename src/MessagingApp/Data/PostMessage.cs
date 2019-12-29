using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApp.Data
{
    public class PostMessage
    {
        public string PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
        public string Message { get; set; }
    }
}
