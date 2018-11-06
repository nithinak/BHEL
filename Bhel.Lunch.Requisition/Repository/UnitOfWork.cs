using Bhel.Lunch.Requisition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bhel.Lunch.Requisition.Repository
{
    public class UnitOfWork : IDisposable
    {
        private RequisitionEntities context = new RequisitionEntities();
        private GenericRepository<Models.Requisition> requisistionRepository;
        private GenericRepository<Models.Status> statusRepository;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public GenericRepository<Models.Requisition> RequsistionRepository
        {
            get
            {

                if (this.requisistionRepository == null)
                {
                    this.requisistionRepository = new GenericRepository<Models.Requisition>(context);
                }
                return requisistionRepository;
            }
        }

        public GenericRepository<Models.Status> StatusRepository
        {
            get
            {

                if (this.statusRepository == null)
                {
                    this.statusRepository = new GenericRepository<Models.Status>(context);
                }
                return statusRepository;
            }
        }
        public void Save()
        {
            context.SaveChangesAsync();
        }
    }
}