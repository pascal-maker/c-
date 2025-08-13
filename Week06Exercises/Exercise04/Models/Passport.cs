using System.ComponentModel.DataAnnotations;

namespace Exercise04.Models
{
    public class Passport
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]

        public string PassportNumber { get; set; }

        public Traveler Traveler { get; set; }


    }
}

//een traveler heeft altijd 1-1paspoort