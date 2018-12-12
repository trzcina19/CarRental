using CarRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

  //      [Min18YearsIfAMember]
        public DateTime? BirthdayDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

       // public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

    }
}