using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Bhel.Lunch.Requisition.Models;

namespace Bhel.Lunch.Requisition.Repository
{
    public class LunchRepository : IRequisition, IDisposable
    {
        public RequisitionEntities context;
        public LunchRepository(RequisitionEntities context)
        {
            this.context = context;
        }
        public void DeleteRequisition(int studentID)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Requisition> GetRequisition()
        {
            return context.Requisitions.ToList();
        }

        public Models.Requisition GetRequisitionID(int requisitionId)
        {
            return context.Requisitions.Find(requisitionId);
        }

        public void InsertRequisition(Models.Requisition requisition)
        {
            try
            {
                Guid ID = new Guid();
                context.usersp_Insert_Requisition(ID, requisition.Indentor, requisition.Date, requisition.InternalTelephoneNumber,
                    requisition.DepartmentCode, requisition.DateOfLunch, requisition.MenuType, requisition.NumberOfGuest, requisition.NumberOfHost,
                    requisition.HODSignature, requisition.IndentorSignature, requisition.GuestInfo);
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.ToString());
            }
           
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateRequisition(Models.Requisition requisition)
        {
            context.Entry(requisition).State = System.Data.Entity.EntityState.Modified;
        }
    }
}