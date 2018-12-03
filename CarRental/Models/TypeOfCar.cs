using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class TypeOfCar
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}