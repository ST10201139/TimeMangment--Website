using System.ComponentModel.DataAnnotations;

namespace Final_POE_TimeMangement.Models
{
    public class Semester
    {
        [Key]

        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public int SemesterWeeks { get; set; }
        public DateTime StartDate { get; set; }

        //add a foreigin key for userID 
        public string UserID { get; set; }

    }
}
