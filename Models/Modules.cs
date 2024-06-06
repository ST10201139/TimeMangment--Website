using System.ComponentModel.DataAnnotations;

namespace Final_POE_TimeMangement.Models
{
    public class Modules
    {
        [Key]

        public int ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int ModuleCredits { get; set; }
        public int ModuleClassHours { get; set; }
        public string Semester { get; set; }
        public int SelfStudyHours { get; set; }
        public int StudyHoursLeft { get; set; }
        //adding foerign key 
        public string UserID { get; set; }

    }
}
