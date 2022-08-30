using Apartmani.Model;
using Lib.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Dal
{
    public interface IRepository
    {
        void AddUser(User user);
        IList<User> LoadUsers();
        User AuthUser(string username, string password);
        DataTable LoadApartmentsReservation();
        DataTable LoadApartment();
        IList<Owner> LoadOwners();
        IList<City> LoadCities();
        IList<Status> LoadStatus();
        void AddApartment(string owner, string status, string city, Apartment apartment);
        IList<Tag> LoadTags();
        void AddTaggedApartment(string apartmentName, string tagName);
        void DeleteApartment(int apartmentId, DateTime dateTime);
        void DeleteTag(int tagId);
        IList<TaggedApartment> LoadTagedApartment();
        void AddTag(string tagName, string tagNameEng, string tagType);
        void UpdateApartment(int apartmentId, int maxAdults, int maxChildren, int totalRooms, int beachDistance);
        void AddRepresentativeImage(string name, byte[] path);
        void AddImage(int apartmentId, string name, byte[] path);
        void DeleteImage(int apartmentId, string name, DateTime deleteDate);
        string ApartmentName(string apartmentName);
    }
}
