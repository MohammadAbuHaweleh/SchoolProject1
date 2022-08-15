using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Courses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [MinLength(3)]
        [MaxLength(15)]
        public String CourseName { get; set; }
        public int TeacherId { get; set; }
        public Teachers teachers { get; set; }

        [Range(1, 25)]
        public int CourseCapacity { get; set; }
    }
}
