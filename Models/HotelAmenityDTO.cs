using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HotelAmenityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter Amenity name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter Description")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Please enter Timing")]
        public string Timing { get; set; }

        [Required(ErrorMessage ="Please enter Icon Style")]
        public string IconStyle { get; set; }
    }
}
