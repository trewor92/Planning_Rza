using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningRZA.DBRepository.Interfaces
{
    public interface IRepositoryContextFactory
    {
        RepositoryContext CreateDbContext(string connectionString);
    }
}
