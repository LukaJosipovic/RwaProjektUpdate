using Apartmani.Model;
using Lib.Model;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Dal
{
    public class DBRepository : IRepository
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void AddApartment(string owner, string status, string city, Apartment apartment)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddApartment), owner, status, city, apartment.Address, apartment.Name, apartment.NameEng, apartment.Price, apartment.MaxAdults, apartment.MaxChildren, apartment.TotalRooms, apartment.BeachDistance);
        }

        public void AddImage(int apartmentId, string name, byte[] path)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddImage), apartmentId, name, path);
        }

        public void AddRepresentativeImage(string name, byte[] path)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddRepresentativeImage), name, path);
        }

        public void AddTag(string tagName, string tagNameEng, string tagType)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddTag), tagName, tagNameEng, tagType);
        }

        public void AddTaggedApartment(string apartmentName, string tagName)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddTaggedApartment), apartmentName, tagName);
        }

        public void AddUser(User user)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddUser), user.UserName, user.Email, user.Address, user.PhoneNumber, user.PasswordHash);
        }

        public string ApartmentName(string apartmentName)
        {
            var name = SqlHelper.ExecuteDataset(CS, nameof(ApartmentName), apartmentName).Tables[0];
            if (name.Rows.Count == 0)
            {
                return null;
            }
            return name.ToString();
        }

        public User AuthUser(string username, string password)
        {
            var tblAuth = SqlHelper.ExecuteDataset(CS, nameof(AuthUser), username, password).Tables[0];
            if (tblAuth.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tblAuth.Rows[0];

            return new User
            {
                Email = row[nameof(User.Email)].ToString(),
                PhoneNumber = row[nameof(User.PhoneNumber)].ToString(),
                UserName = row[nameof(User.UserName)].ToString(),
                Address = row[nameof(User.Address)].ToString(),
                PasswordHash = row[nameof(User.PasswordHash)].ToString()
            };
        }

        public void DeleteApartment(int apartmentId, DateTime dateTime)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteApartment), apartmentId, dateTime);
        }

        public void DeleteImage(int apartmentId, string name, DateTime deleteDate)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteImage), apartmentId, name, deleteDate);
        }

        public void DeleteTag(int tagId)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteTag), tagId);
        }

        public DataTable LoadApartment()
        {
            DataTable tblApartment = SqlHelper.ExecuteDataset(CS, nameof(LoadApartment)).Tables[0];
            
            return tblApartment;
        }

        public DataTable LoadApartmentsReservation()
        {
            DataTable tblApartmentReservation = SqlHelper.ExecuteDataset(CS, nameof(LoadApartmentsReservation)).Tables[0];

            return tblApartmentReservation;
        }

        public IList<City> LoadCities()
        {
            IList<City> cities = new List<City>();

            var tblCities = SqlHelper.ExecuteDataset(CS, nameof(LoadCities)).Tables[0];
            foreach (DataRow row in tblCities.Rows)
            {
                cities.Add(
                    new City
                    {
                        Name = row[nameof(City.Name)].ToString(),
                    }
                );
            }

            return cities;
        }

        public IList<Owner> LoadOwners()
        {
            IList<Owner> owners = new List<Owner>();

            var tblOwners = SqlHelper.ExecuteDataset(CS, nameof(LoadOwners)).Tables[0];
            foreach (DataRow row in tblOwners.Rows)
            {
                owners.Add(
                    new Owner
                    {
                        Name = row[nameof(Owner.Name)].ToString(),
                    }
                );
            }

            return owners;
        }

        public IList<Status> LoadStatus()
        {
            IList<Status> statuses = new List<Status>();

            var tblStatus = SqlHelper.ExecuteDataset(CS, nameof(LoadStatus)).Tables[0];
            foreach (DataRow row in tblStatus.Rows)
            {
                statuses.Add(
                    new Status
                    {
                        Name = row[nameof(Status.Name)].ToString(),
                    }
                );
            }

            return statuses;
        }

        public IList<TaggedApartment> LoadTagedApartment()
        {
            IList<TaggedApartment> taggedApartments = new List<TaggedApartment>();
            var tblTaggedApartment = SqlHelper.ExecuteDataset(CS, nameof(LoadTagedApartment)).Tables[0];
            foreach (DataRow row in tblTaggedApartment.Rows)
            {
                taggedApartments.Add(
                    new TaggedApartment
                    {
                        Id = (int)row[nameof(TaggedApartment.Id)],
                        ApartmentId = (int)row[nameof(TaggedApartment.ApartmentId)],
                        TagId = (int)row[nameof(TaggedApartment.TagId)]
                    }
                );
            }

            return taggedApartments;
        }

        public IList<Tag> LoadTags()
        {
            IList<Tag> tags = new List<Tag>();
            var tblTags = SqlHelper.ExecuteDataset(CS, nameof(LoadTags)).Tables[0];
            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(
                    new Tag
                    {
                        Id = (int)row[nameof(Tag.Id)],
                        CreatedAt = DateTime.Parse(row[nameof(Tag.CreatedAt)].ToString()),
                        TypeId = (int)row[nameof(Tag.TypeId)],
                        Name = row[nameof(Tag.Name)].ToString(),
                        NameEng = row[nameof(Tag.NameEng)].ToString(),
                    }
                );
            }
            return tags;
        }

        public IList<User> LoadUsers()
        {
            IList<User> users = new List<User>();

            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(LoadUsers)).Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                users.Add(
                    new User
                    {
                        Id = (int)row[nameof(User.Id)],
                        Email = row[nameof(User.Email)].ToString(),
                        PhoneNumber = row[nameof(User.PhoneNumber)].ToString(),
                        UserName = row[nameof(User.UserName)].ToString(),
                        Address = row[nameof(User.Address)].ToString()
                    }
                );
            }

            return users;
        }

        public void UpdateApartment(int apartmentId, int maxAdults, int maxChildren, int totalRooms, int beachDistance)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(UpdateApartment), apartmentId, maxAdults, maxChildren, totalRooms, beachDistance);
        }
    }
}
