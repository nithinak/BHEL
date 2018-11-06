using Bhel.Lunch.Requisition.Repository;
using System.Collections.Generic;
using System.Linq;
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
            List<Models.Requisition> requisitionDetails = unitOfWork.RequsistionRepository.Get().ToList();

            if (requisitionDetails.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(requisitionDetails);
            }

        }
        [HttpPost]
        public IHttpActionResult CreateNewRequisition([FromBody] ViewModel.Requsition requisition)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            else
            {
                Models.Requisition RequisitionsDetails = new Models.Requisition()
                {
                    Id = requisition.Id,
                    Indentor = requisition.Indentor,
                    IndentorSignature = requisition.IndentorSignature,
                    MenuType = requisition.MenuType,
                    Date = requisition.Date,
                    DateOfLunch = requisition.DateOfLunch,
                    GuestInfo = requisition.GuestInfo,
                    DepartmentCode = requisition.DepartmentCode,
                    InternalTelephoneNumber = requisition.InternalTelephoneNumber,
                    NumberOfGuest = requisition.NumberOfGuest,
                    NumberOfHost = requisition.NumberOfHost,
                    StatusCode = unitOfWork.StatusRepository.GetByID(101).Id,

                };

                unitOfWork.RequsistionRepository.Insert(RequisitionsDetails);
                unitOfWork.Save();
            }
            return Ok();
        }
    }
}
