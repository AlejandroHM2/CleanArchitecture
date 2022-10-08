using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Clean.Architecture.Repositories.DataContext
{
    internal class CleanArchitectureContextFactory
        : IDesignTimeDbContextFactory<CleanArchitectureContext>
    {
        public CleanArchitectureContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder optionsBuilder =
                new DbContextOptionsBuilder<CleanArchitectureContext>();
            optionsBuilder.UseSqlServer(
                "Server=.;Database=CleanArchitecture;User Id=sa;Password=4rquetipo!;");
            return new CleanArchitectureContext(optionsBuilder.Options);
        }
    }
}
