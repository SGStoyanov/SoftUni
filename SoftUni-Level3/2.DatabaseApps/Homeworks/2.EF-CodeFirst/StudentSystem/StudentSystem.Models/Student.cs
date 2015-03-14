namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        private ICollection<Course> courses; 

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [ForeignKey("Courses")]
        public int CourseId { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        } 
    }
}