using System;
using System.Collections.Generic;

namespace Sis.Interview.Models.ScrumCeremony
{
    public class Retrospective : IEntity
    {
        public string Name { get; set; }
        public string Summary { get; set; } 
        public DateTime Date { get; set; }
        public IList<string> Participants { get; set; }
        public IList<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
