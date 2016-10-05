using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using Sis.Interview.Api.Framework;
using Sis.Interview.Models.ScrumCeremony;

namespace Sis.Interview.Api.Models.ScrumCeremony
{
    public class RetrospectiveCreate: Retrospective
    {
        [Required]
        public   string Name { get; set; } 

        [Required]
        public string Date { get; set; }

        [FilledCollection]
        public   IEnumerable<string> Participants { get; set; } }
}
