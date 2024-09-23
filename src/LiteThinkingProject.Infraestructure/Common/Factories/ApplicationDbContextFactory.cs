using LiteThinkingProject.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LiteThinkingProject.Infraestructure.Common.Factories
{
    internal class ApplicationDbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<ApplicationDbContext> options;

        public ApplicationDbContextFactory(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }

        public DbContext Create()
        {
            return new ApplicationDbContext(this.options);
        }
    }
}