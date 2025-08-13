using System.ComponentModel.DataAnnotations;

namespace Exercise04.Models
{
    public class Traveler
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]

        public string FullName { get; set; }

        public Passport Passport { get; set; }

        public ICollection<Destination> Destinations { get; set; }






    }
}

//eentteaverler heefteenaspoot nidig en kan anar meerdere destinations