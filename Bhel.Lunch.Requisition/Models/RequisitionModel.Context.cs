﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bhel.Lunch.Requisition.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RequisitionEntities : DbContext
    {
        public RequisitionEntities()
            : base("name=RequisitionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentTable> DepartmentTables { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LunchType> LunchTypes { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<RequisistionStatu> RequisistionStatus { get; set; }
    
        public virtual int usersp_Insert_Requisition(Nullable<System.Guid> iD, string iNDENTOR, Nullable<System.DateTime> dATEOFENTRY, Nullable<int> iNTERNALTELEPHONE, string dEPARTMENTCODE, Nullable<System.DateTime> dATEOFLUNCH, string mENUTYPE, Nullable<int> nUMBEROFGUEST, Nullable<int> nUMBEROFHOST, byte[] hODSIGN, byte[] iNDENTORSIGN, string gUESTINFO)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(System.Guid));
    
            var iNDENTORParameter = iNDENTOR != null ?
                new ObjectParameter("INDENTOR", iNDENTOR) :
                new ObjectParameter("INDENTOR", typeof(string));
    
            var dATEOFENTRYParameter = dATEOFENTRY.HasValue ?
                new ObjectParameter("DATEOFENTRY", dATEOFENTRY) :
                new ObjectParameter("DATEOFENTRY", typeof(System.DateTime));
    
            var iNTERNALTELEPHONEParameter = iNTERNALTELEPHONE.HasValue ?
                new ObjectParameter("INTERNALTELEPHONE", iNTERNALTELEPHONE) :
                new ObjectParameter("INTERNALTELEPHONE", typeof(int));
    
            var dEPARTMENTCODEParameter = dEPARTMENTCODE != null ?
                new ObjectParameter("DEPARTMENTCODE", dEPARTMENTCODE) :
                new ObjectParameter("DEPARTMENTCODE", typeof(string));
    
            var dATEOFLUNCHParameter = dATEOFLUNCH.HasValue ?
                new ObjectParameter("DATEOFLUNCH", dATEOFLUNCH) :
                new ObjectParameter("DATEOFLUNCH", typeof(System.DateTime));
    
            var mENUTYPEParameter = mENUTYPE != null ?
                new ObjectParameter("MENUTYPE", mENUTYPE) :
                new ObjectParameter("MENUTYPE", typeof(string));
    
            var nUMBEROFGUESTParameter = nUMBEROFGUEST.HasValue ?
                new ObjectParameter("NUMBEROFGUEST", nUMBEROFGUEST) :
                new ObjectParameter("NUMBEROFGUEST", typeof(int));
    
            var nUMBEROFHOSTParameter = nUMBEROFHOST.HasValue ?
                new ObjectParameter("NUMBEROFHOST", nUMBEROFHOST) :
                new ObjectParameter("NUMBEROFHOST", typeof(int));
    
            var hODSIGNParameter = hODSIGN != null ?
                new ObjectParameter("HODSIGN", hODSIGN) :
                new ObjectParameter("HODSIGN", typeof(byte[]));
    
            var iNDENTORSIGNParameter = iNDENTORSIGN != null ?
                new ObjectParameter("INDENTORSIGN", iNDENTORSIGN) :
                new ObjectParameter("INDENTORSIGN", typeof(byte[]));
    
            var gUESTINFOParameter = gUESTINFO != null ?
                new ObjectParameter("GUESTINFO", gUESTINFO) :
                new ObjectParameter("GUESTINFO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usersp_Insert_Requisition", iDParameter, iNDENTORParameter, dATEOFENTRYParameter, iNTERNALTELEPHONEParameter, dEPARTMENTCODEParameter, dATEOFLUNCHParameter, mENUTYPEParameter, nUMBEROFGUESTParameter, nUMBEROFHOSTParameter, hODSIGNParameter, iNDENTORSIGNParameter, gUESTINFOParameter);
        }

        public System.Data.Entity.DbSet<Bhel.Lunch.Requisition.ViewModel.Requsition> Requsitions { get; set; }
    }
}
