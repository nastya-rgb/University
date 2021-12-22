using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int DisciplineId {get;set;}
        public Discipline Discipline {get;set;}
    }
}