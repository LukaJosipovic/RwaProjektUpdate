using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ApartmaniMVC.Models
{
    public class Repo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static IList<User> LoadUsers()
        {
            IList<User> users = new List<User>();

            var tblUsers = SqlHelper.ExecuteDataset(cs, nameof(LoadUsers)).Tables[0];
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

        public static User AuthUser(string username, string password)
        {
            var tblAuth = SqlHelper.ExecuteDataset(cs, nameof(AuthUser), username, password).Tables[0];
            if (tblAuth.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tblAuth.Rows[0];

            return new User
            {
                Id = (int)row[nameof(User.Id)],
                Email = row[nameof(User.Email)].ToString(),
                PhoneNumber = row[nameof(User.PhoneNumber)].ToString(),
                UserName = row[nameof(User.UserName)].ToString(),
                Address = row[nameof(User.Address)].ToString(),
                PasswordHash = row[nameof(User.PasswordHash)].ToString()
            };
        }

        public static DataTable LoadApartment()
        {
            var tblApartment = SqlHelper.ExecuteDataset(cs, nameof(LoadApartment)).Tables[0];

            return tblApartment;
        }

        public static DataTable LoadApartmentById(int id)
        {
            var tblApartmentById = SqlHelper.ExecuteDataset(cs, nameof(LoadApartmentById), id).Tables[0];

            return tblApartmentById;
        }

        public static DataTable LoadApartmentWithImage()
        {
            var tblApartmentWithImage = SqlHelper.ExecuteDataset(cs, nameof(LoadApartmentWithImage)).Tables[0];

            return tblApartmentWithImage;
        }

        public static DataTable LoadApartmentImage(int id)
        {
            var tblApartmentImage = SqlHelper.ExecuteDataset(cs, nameof(LoadApartmentImage), id).Tables[0];

            return tblApartmentImage;
        }

        public static void AddReservation(int apartmentId, string details, int userId, string userName, string userEmail, string userPhone, string userAddress)
        {
            SqlHelper.ExecuteNonQuery(cs, nameof(AddReservation), apartmentId, details, userId, userName, userEmail, userPhone, userAddress);
        }

        public static DataTable LoadTagedApartment()
        {
            var taggedApartments = SqlHelper.ExecuteDataset(cs, nameof(LoadTagedApartment)).Tables[0];

            return taggedApartments;
        }

        public static DataTable LoadTagedApartmentById(int id)
        {
            var taggedApartmentsById = SqlHelper.ExecuteDataset(cs, nameof(LoadTagedApartmentById), id).Tables[0];

            return taggedApartmentsById;
        }

        public static DataTable LoadReview(int id)
        {
            var apartmentReview = SqlHelper.ExecuteDataset(cs, nameof(LoadReview), id).Tables[0];

            return apartmentReview;
        }

        public static void AddReview(int apartmentId, int userId, string details, int stars)
        {
            SqlHelper.ExecuteNonQuery(cs, nameof(AddReview), apartmentId, userId, details, stars);
        }
    }
}