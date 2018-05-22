using System;

namespace ContosoUniversity.Models.SchoolViewModels
{
    public class StudentsViewModel : Person
    {
        public DateTime EnrollmentDate { get; set; }
    }
}