using Microsoft.EntityFrameworkCore;

namespace LiteThinkingProject.Infraestructure.Common.Factories
{
    public interface IDbContextFactory
    {
        DbContext Create();
    }

}

