using System;

namespace DataAccessLibrary.Models
{
    public class PostMessageModel
    {
        public string PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
        public string Message { get; set; }
    }
}