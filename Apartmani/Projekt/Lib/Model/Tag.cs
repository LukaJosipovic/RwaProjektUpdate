using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public Guid Guid  { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Tag tag &&
                   Name == tag.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
