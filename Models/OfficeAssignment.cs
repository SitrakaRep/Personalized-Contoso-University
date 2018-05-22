using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        [DisplayFormat(NullDisplayText = "No Office")]
        public string Location { get; set; }
        public Instructor Instructor { get; set; }
    }
}