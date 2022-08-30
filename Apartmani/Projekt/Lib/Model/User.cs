using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartmani.Model
{
    public class User
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public string Email { get; set; }
        public byte EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public byte PhoneNumberConfirmed { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public byte LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   UserName == user.UserName;
        }

        public override int GetHashCode()
        {
            return 404878561 + EqualityComparer<string>.Default.GetHashCode(UserName);
        }
    }
}