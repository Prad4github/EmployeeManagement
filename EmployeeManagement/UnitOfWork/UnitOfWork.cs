using EmployeeManagement.Models;
using EmployeeManagement.Repository;

namespace EmployeeManagement.UnitOfWork
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly ApiContext _context;

        public UnitOfwork(ApiContext context)
        {
            _context = context;
            ManagersRepository = new ManagerRepository(_context);
            ClientRepository = new ClientRepository(_context);
        }

        public IManagerRepository ManagersRepository { get; private set; }

        public IClientsRepository ClientRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
