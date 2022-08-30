using ApartmaniMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApartmaniMVC.Controllers.api
{
    public class TagController : ApiController
    {
        // GET: api/Tag
        public IHttpActionResult Get()
        {
            return Json(Repo.LoadTagedApartment());
        }

        // GET: api/Tag/5
        public IHttpActionResult Get(int id)
        {
            return Json(Repo.LoadTagedApartmentById(id));
        }

        // POST: api/Tag
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tag/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tag/5
        public void Delete(int id)
        {
        }
    }
}
