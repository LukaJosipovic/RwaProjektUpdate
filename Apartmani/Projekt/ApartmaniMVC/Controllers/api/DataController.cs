using ApartmaniMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApartmaniMVC.Controllers
{
    public class DataController : ApiController
    {
        // GET: api/Data
        public IHttpActionResult Get()
        {
            return Json(Repo.LoadApartmentWithImage());
        }

        // GET: api/Data/5
        public IHttpActionResult Get(int id)
        {
            return Json(Repo.LoadApartmentById(id));
        }

        // POST: api/Data
        public void Post([FromBody]ApartmentReservation reservation)
        {
            Repo.AddReservation(reservation.ApartmentId, reservation.Details, reservation.UserId, reservation.UserName, reservation.UserEmail, reservation.UserPhone, reservation.UserAddress);
        }

        // PUT: api/Data/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Data/5
        public void Delete(int id)
        {
        }
    }
}
