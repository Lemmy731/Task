using System.ComponentModel.DataAnnotations;

namespace MiskStartupSchool.Entities
{
    public class Stage
    {
        [Key]
        public string StageId { get; set; }
        public string StageName { get; set; }
        public string Shortlistings { get; set; }
        public string Placement { get; set; }
        public ICollection<InterviewQuestions>? InterviewQuestion{ get; set; } 
    }

    public class InterviewQuestions
    {
        [Key]
        public string InterviewId { get; set; }
        public string VideoUrl { get; set; }
        public string Statement { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
