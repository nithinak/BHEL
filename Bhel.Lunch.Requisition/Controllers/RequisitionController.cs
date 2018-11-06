using Bhel.Lunch.Requisition.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bhel.Lunch.Requisition.Controllers
{
    public class RequisitionController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public RequisitionController()
        {

        }
        [HttpGet]
        public IHttpActionResult GetRequisition()
        {
            var requisitionDetails = unitOfWork.RequsistionRepository.Get().ToList();
            if (requisitionDetails.Count==0)
            {
                return NotFound();
            }
            else
            {
                return Ok(requisitionDetails);
            }
           
        }
    }
}
