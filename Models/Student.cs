using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthaday { get; set; }
        public int Course { get; set; }
        public string Nationality { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }
        public string Addres { get; set; }
        public List<Discipline> Disciplines {get;set;}
    }
}