using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace Bhel.Lunch.Requisition.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {

            IEnumerable<ViewModel.Requsition> requisitionDetails = null;
            using (HttpClient Clinet = new HttpClient())
            {
                Clinet.BaseAddress = new Uri("http://localhost:51821/api/");
                //HTTP GET
                System.Threading.Tasks.Task<HttpResponseMessage> responseTask = Clinet.GetAsync("Requisition");
                responseTask.Wait();

                HttpResponseMessage result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<IList<ViewModel.Requsition>> readTask = result.Content.ReadAsAsync<IList<ViewModel.Requsition>>();
                    readTask.Wait();
                    requisitionDetails = readTask.Result;
                }
                else
                {
                    //log response status here..

                    requisitionDetails = Enumerable.Empty<ViewModel.Requsition>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(requisitionDetails);

        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(ViewModel.Requsition requisition)
        {

            requisition.Id = Guid.NewGuid();
          
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51821/api/");

                //HTTP POST
                System.Threading.Tasks.Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("requisition", requisition);
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

