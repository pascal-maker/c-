using System.ComponentModel.DataAnnotations;
namespace Exercise04.Models
{
    public class Destination
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]

        public string Name { get; set; }

        public ICollection<Traveler> Travelers { get; set; }

    }
}
//vergeten using System.ComponentModel.DataAnnotations dit hbe je nodig voor ewuiered en malenght;
//[Required]
        //[MaxLength(200)]

        //je mmoet rkenen meerdere rezigers kunnen naar dezefde destinatoin
