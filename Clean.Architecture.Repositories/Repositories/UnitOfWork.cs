using Clean.Architecture.Entities.Interfaces;
using Clean.Architecture.Repositories.DataContext;

namespace Clean.Architecture.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly CleanArchitectureContext context;
        public UnitOfWork(CleanArchitectureContext context)
            => this.context = context;

        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
    }
}
