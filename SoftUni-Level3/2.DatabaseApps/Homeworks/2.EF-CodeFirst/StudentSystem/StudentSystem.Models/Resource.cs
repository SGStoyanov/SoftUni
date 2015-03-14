namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        private ICollection<Course> courses;

        public Resource()
        {
            this.Courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [MaxLength(250)]
        public string Link { get; set; }

        public ICollection<Course> Courses
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