using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmaniMVC.Models
{
    public class ApartmentInfo
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public decimal Price { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int TotalRooms { get; set; }
        public int BeachDistance { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public byte[] ImageData { get; set; }
    }
}