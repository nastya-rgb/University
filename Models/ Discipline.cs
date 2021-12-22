using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Discipline
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 

         public List<Student> Students {get;set;}

    }
}