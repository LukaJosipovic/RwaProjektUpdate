using ApartmaniMVC.Models;
using CaptchaMvc.HtmlHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ApartmaniMVC.Controllers
{
    public class HomeController : Controller
    {
        private static HttpClient client = new HttpClient();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            if (ModelState.IsValid)
            {
                u.PasswordHash = Cryptography.SHA512.HashPassword(u.PasswordHash);
                User user = Repo.AuthUser(u.UserName, u.PasswordHash);
                Session["login"] = user;
                return View("Login");
            }
            else
            {
                return Index();
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();

            return View();
        }

        public async Task<ActionResult> Apartmani()
        {
            HttpCookie cookie = Request.Cookies["sortCookie"];
            if (cookie != null) 
            {
                return RedirectToAction("ApartmaniCookie", "Home");
            }
            string host = Host() + "/api/Data";

            List<ApartmentInfo> apartments = await GetApartments<List<ApartmentInfo>>(host);
            ViewBag.json = apartments;
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ApartmaniSorted(FormCollection form)
        {
            HttpCookie sortCookie = new HttpCookie("sortCookie", form["sort"]);
            sortCookie.Expires = DateTime.Now.AddMinutes(1);
            Response.SetCookie(sortCookie);

            string host = Host() + "/api/Data";
            List<ApartmentInfo> apartments = await GetApartments<List<ApartmentInfo>>(host);

            apartments = SortApartments(form["sort"], apartments);
            ViewBag.json = apartments;

            return View("Apartmani");
        }

        public async Task<ActionResult> ApartmaniCookie()
        {
            HttpCookie cookie = Request.Cookies["sortCookie"];
            if (cookie == null)
            {
                return RedirectToAction("Apartmani", "Home");
            }

            string host = Host() + "/api/Data";
            List<ApartmentInfo> apartments = await GetApartments<List<ApartmentInfo>>(host);

            apartments = SortApartments(cookie.Value, apartments);
            ViewBag.json = apartments;

            return View("Apartmani");
        }

        private static List<ApartmentInfo> SortApartments(string sort, List<ApartmentInfo> apartments)
        {
            if (sort == null || sort == "Default")
            {
                apartments = apartments.OrderBy(x => x.Id).ToList();
            }
            else if (sort == "Growing")
            {
                apartments = apartments.OrderBy(x => x.Price).ToList();
            }
            else if (sort == "Falling")
            {
                apartments = apartments.OrderBy(x => -x.Price).ToList();
            }

            return apartments;
        }

        [HttpPost]
        public async Task<ActionResult> Apartmani(int id)
        {
            List<ApartmentInfo> apartment = await GetApartments<List<ApartmentInfo>>(Host() + "/api/Data/" + id.ToString());
            ViewBag.json = apartment;

            List<TaggedApartment> taggedApartments = await GetApartments<List<TaggedApartment>>(Host() + "/api/Tag/" + id.ToString());
            ViewBag.jsonTag = taggedApartments;

            List<ApartmentReview> apartmentReviews = await GetApartments<List<ApartmentReview>>(Host() + "/api/Review/" + id.ToString());
            ViewBag.jsonReviews = apartmentReviews;

            List<ApartmentImage> apartmentImages = await GetApartments<List<ApartmentImage>>(Host() + "/api/Image/" + id.ToString());
            ViewBag.jsonImage = apartmentImages;

            return View("Apartman");
        }

        [HttpPost]
        public async Task<ActionResult> ApartmanReservation(ApartmentReservation apartmentReservation)
        {   
            if (ModelState.IsValid && (this.IsCaptchaValid("Captcha is not valid") || Session["login"] != null))
            {
                string host = Host() + "/api/Data/";

                var json = JsonConvert.SerializeObject(apartmentReservation);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(host, data);            

                return View(apartmentReservation);
            }
            else
            {
                return await Apartmani(apartmentReservation.ApartmentId);
            }
        }

        [HttpPost]
        public ActionResult Review(int ApartmentId)
        {
            ViewBag.apartmentId = ApartmentId;
            return View();
        }

        [HttpPost]
        public ActionResult ReviewAdded(int ApartmentId, int UserId, string Comment, int Stars)
        {
            Repo.AddReview(ApartmentId, UserId, Comment, Stars);

            return View();
        }

        private static async Task<T> GetApartments<T>(string host)
        {
            var response = await client.GetStringAsync(host);
            T data = JsonConvert.DeserializeObject<T>(response);
            return data;
        }

        private string Host()
        {
            Uri uri = HttpContext.Request.Url;
            string url = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

            return url;
        }

    }
}