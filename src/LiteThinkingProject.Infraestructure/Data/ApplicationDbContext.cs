using LiteThinkingProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiteThinkingProject.Infraestructure.Data
{
    internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), Application.Commons.Interfaces.IApplicationDbContext
    {
        public DbSet<Activity> Activity { get; set; }
    }
}