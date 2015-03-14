namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        public int StudentId { get; set; }

        public virtual Student HomeworkSubmitter { get; set; }

        public int CourseId { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public virtual Course Course { get; set; }
    }
}