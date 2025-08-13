using System.ComponentModel.DataAnnotations;

namespace Exercise04.Models
{
    public class Tour
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]



        public string Title { get; set; }


        public int GuideId { get; set; }


        public Guide Guide { get; set; }




    }
}
//inderdaad per tour ene guide maar guideid vergeten