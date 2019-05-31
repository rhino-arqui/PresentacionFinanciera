using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebFinanciaera.Models;

namespace WebFinanciaera.Controllers
{
    public class ProxyWSRESTController : Controller
    {
        // GET: ProxyWSREST
        public ActionResult Index()
        {
            IEnumerable<CARDS> libro = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58727/api/");
                //HTTP GET
                var responseTask = client.GetAsync("CARDS");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList< CARDS>> ();
                    readTask.Wait();

                    libro = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    libro = Enumerable.Empty<CARDS>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(libro);

        }

        // GET: ProxyWSREST/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProxyWSREST/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProxyWSREST/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProxyWSREST/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProxyWSREST/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProxyWSREST/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProxyWSREST/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
