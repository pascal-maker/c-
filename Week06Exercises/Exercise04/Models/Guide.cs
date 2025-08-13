using System.ComponentModel.DataAnnotations;
namespace Exercise04.Models
{
    public class Guide
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]

        public string Name { get; set; }

        public ICollection<Tour> Tours { get; set; }


    }
}

//eenguidekanmeerdere tours doenpublic ICollection<Tour> Tours { get; set; }