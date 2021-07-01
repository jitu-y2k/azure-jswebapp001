using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    public class Student
    {
        [Key]
        [Column("StudentId")]
        [Required]        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(18, 60)]
        public int Age { get; set; }

        [NotMapped]
        public int LocalCalculation { get; set; }

        public bool IsRegularStudent { get; set; }

    }
}


