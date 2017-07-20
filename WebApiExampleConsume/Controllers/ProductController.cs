using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebApiExampleConsume.Models;

namespace WebApiExampleConsume.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59102");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/product").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            }

            else
            {
                ViewBag.result = "Error";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View("Search");
        }

        [HttpPost]
        public ActionResult Search(FormCollection fc)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59102");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/product/" + fc["id"]).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<Product>().Result;
            }

            else
            {
                ViewBag.result = "Error";
            }
            return View("Search");
        }
    }
}