using System;
using System.Collections.Generic;
using System.Text;

namespace ViewingSystem.Models
{
    public class Caller
    {
        public int Id { get; set; }
        public string Outbound { get; set; }
        public string Extension { get; set; }
        public string CallerNumber { get; set; }
        public int Recording { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public DateTime Duration { get; set; }
        public DateTime TimeBetweenCalls { get; set; }
        public int  UserId { get; set; }
        public User User { get; set; }

    }
}
