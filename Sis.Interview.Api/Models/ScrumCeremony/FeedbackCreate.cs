using System.ComponentModel.DataAnnotations;
using Sis.Interview.Models.ScrumCeremony;

namespace Sis.Interview.Api.Models.ScrumCeremony
{
    public class FeedbackCreate: Feedback
    {
        [Required]
        public new string NameCreatedBy { get; set; }

        [Required]
        public new FeedbackType? Type { get; set; }
    }
}
