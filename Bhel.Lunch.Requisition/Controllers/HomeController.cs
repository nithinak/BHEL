using Bhel.Lunch.Requisition.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace Bhel.Lunch.Requisition.Controllers
{
    public class HomeController : Controller
    {
     
        [HttpGet]
        public ActionResult Index()
        {
            
            IEnumerable<Models.Requisition> requisitionDetails = null;
            using (var Clinet = new HttpClient())
            {
                Clinet.BaseAddress = new Uri("http://localhost:51821/api/");
                //HTTP GET
                var responseTask = Clinet.GetAsync("Requisition");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Models.Requisition>>();
                    readTask.Wait();

                    requisitionDetails = readTask.Result;
                }
            }

            return View(requisitionDetails);
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Requisition requisition)
        {

            requisition.Id = Guid.NewGuid();
           
            RequisistionStatu requisistionStatu = new RequisistionStatu()
            {
                RequisitionID = requisition.Id,
                Status = 101,

            };
            requisition.RequisistionStatu = requisistionStatu;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51821/api/");

                //HTTP POST
                System.Threading.Tasks.Task<HttpResponseMessage> postTask = client.PostAsJsonAsync<Models.Requisition>("requisition", requisition);
                postTask.Wait();

                HttpResponseMessage result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(requisition);
        }

    }
}

