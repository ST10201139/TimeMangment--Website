using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_POE_TimeMangement.Models
{
    public class StudyHours
    {
        [Key]

        public int StudyHourId { get; set; }
        // Foreign key property
        [ForeignKey("StudyModule")] // Specify the navigation property name
        public int ModuleId { get; set; }
        public Modules StudyModule { get; set; }
        public DateTime StudyDate { get; set; }
        public double Hours { get; set; }
        //adding foerign key 
        public string UserID { get; set; }


        // Calculate the week number based on the Date property
        public int NumberOFWeeks {
            get {// Assuming each week has 7 days
          return (int)Math.Ceiling(StudyDate.DayOfYear / 7.0);
            }
        }
    }
}
