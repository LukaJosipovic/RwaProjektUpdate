using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApartmaniMVC.Models
{
    public class ApartmentReservation
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ApartmentId { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string Details { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string UserPhone { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string UserAddress { get; set; }
    }
}