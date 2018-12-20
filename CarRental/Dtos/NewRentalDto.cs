using System.Collections.Generic;

namespace CarRental.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> CarIds { get; set; }
    }
}