using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bhel.Lunch.Requisition.ViewModel
{
    public class Requsition
    {
        public System.Guid Id { get; set; }
        public string Indentor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> InternalTelephoneNumber { get; set; }
        public string DepartmentCode { get; set; }
        public Nullable<System.DateTime> DateOfLunch { get; set; }
        public string MenuType { get; set; }
        public Nullable<int> NumberOfGuest { get; set; }
        public Nullable<int> NumberOfHost { get; set; }
        public string GuestInfo { get; set; }
        public byte[] HODSignature { get; set; }
        public byte[] IndentorSignature { get; set; }

        public virtual RequisistionStatu RequisistionStatu { get; set; }
    }
    public partial class RequisistionStatu
    {
        public System.Guid RequisitionID { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<bool> Status { get; set; }

    }
}