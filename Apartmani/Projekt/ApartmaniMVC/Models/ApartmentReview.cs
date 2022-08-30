using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmaniMVC.Models
{
    public class ApartmentReview
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Details { get; set; }
        public string Stars { get; set; }
    }
}