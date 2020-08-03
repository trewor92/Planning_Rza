using PlanningRZA.DBRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningRZA.DBRepository.Repositories
{
    public class BaseRepository
    {
        protected string ConnectionString { get; }
        protected IRepositoryContextFactory ContextFactory { get; }
        public BaseRepository(string connectionString, IRepositoryContextFactory contextFactory)
        {
            ConnectionString = connectionString;
            ContextFactory = contextFactory;
        }
    }
}
