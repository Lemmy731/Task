using System.ComponentModel.DataAnnotations;

namespace MiskStartupSchool.Entities
{
    public class MyProgramTemp : MyProgramDetails
    {
        public string ProgramTitle { get; set; }
        public string ProgramSummary { get; set; }
        public string ProgramDescription { get; set; }
        public string KeySkills { get; set; }
        public string ProgramBenefits { get; set; }
        public string ApplicationCriteria { get; set; }
    }
}
