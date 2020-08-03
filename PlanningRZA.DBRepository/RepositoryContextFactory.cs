using Microsoft.EntityFrameworkCore;
using PlanningRZA.DBRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningRZA.DBRepository
{
	public class RepositoryContextFactory : IRepositoryContextFactory
	{
		public RepositoryContext CreateDbContext(string connectionString)
		{
			var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
			optionsBuilder.UseSqlServer(connectionString);

			return new RepositoryContext(optionsBuilder.Options);
		}
	}
}
