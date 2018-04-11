using System;

namespace DAL.Unit_of_work
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext DbContext { get; }

        int Save();
    }
}
