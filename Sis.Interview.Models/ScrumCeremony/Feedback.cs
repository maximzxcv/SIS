namespace Sis.Interview.Models.ScrumCeremony
{
    public class Feedback
    {
        public string NameCreatedBy { get; set; }
        public string Body { get; set; }
        public FeedbackType Type { get; set; }
        public string TypeString => Type.ToString();
    }
}
