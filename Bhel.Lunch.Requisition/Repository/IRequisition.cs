using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bhel.Lunch.Requisition.Models;

namespace Bhel.Lunch.Requisition.Repository
{
    interface IRequisition:IDisposable
    {
        IEnumerable<Models.Requisition> GetRequisition();
        Models.Requisition GetRequisitionID(int studentId);
        void InsertRequisition(Models.Requisition student);
        void DeleteRequisition(int studentID);
        void UpdateRequisition(Models.Requisition student);
        void Save();
    }
}
