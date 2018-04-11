using System;

namespace DAL.Unit_of_work
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;

        public UnitOfWork()
        {
        }

        public ApplicationDbContext DbContext
        {
            get
            {
                if (context == null)
                {
                    context = new ApplicationDbContext();
                }
                return context;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}