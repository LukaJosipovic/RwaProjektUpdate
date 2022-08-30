using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class TaggedApartment
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int ApartmentId { get; set; }
        public int TagId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TaggedApartment apartment &&
                   TagId == apartment.TagId;
        }

        public override int GetHashCode()
        {
            return 1948533646 + TagId.GetHashCode();
        }
    }
}
