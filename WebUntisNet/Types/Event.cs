using System;
using System.Collections.Generic;
using System.Text;

namespace WebUntisNet.Types
{
    public class Event
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Reason { get; set; }
        public string Text { get; set; }
    }
}