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
        private UnitOfWork UnitOfWork = new UnitOfWork(); 
        // GET: api/Requisition
        [HttpGet]
        public IHttpActionResult Get()
        {
            var Requsistion = UnitOfWork.RequsistionRepository.Get().ToList();
            return Ok(Requsistion);
        }

        // GET: api/Requisition/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Requisition
        public IHttpActionResult Post([FromBody]Models.Requisition requisition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
               
            else
            {
               
                UnitOfWork.RequsistionRepository.Insert(requisition);
               
                UnitOfWork.Save();
                return Ok();
            }
          
        }

        // PUT: api/Requisition/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Requisition/5
        public void Delete(int id)
        {
        }
    }
}
