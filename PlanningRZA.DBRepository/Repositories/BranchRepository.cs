using PlanningRZA.DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using PlanningRZA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRZA.DBRepository.Repositories
{
	public class BranchRepository : BaseRepository, IBranchRepository
	{
		public BranchRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

		public Task AddBranch(Branch branch)
		{
			throw new NotImplementedException();
		}

		public Task DeleteBranch(int branchId)
		{
			throw new NotImplementedException();
		}

		public Task EditBranch(Branch branch, int branchId)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Branch>> GetAllBranches(bool deep)
		{
			List<Branch> result;
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				var query = context.Branches.AsQueryable();
				
				if (deep)
					query = query.Include(b => b.Substations);

				result = await query.ToListAsync();
			}
			return result;
		}

		public async Task<Branch> GetBranch(int branchId, bool deep=false)
		{
			Branch result;
			using (var context = ContextFactory.CreateDbContext(ConnectionString)) 
			{
				var query = context.Branches.AsQueryable();
					query = query.Where(b => b.Id==branchId);

				if (deep)
					query = query.Include(b => b.Substations);

				result = await query.FirstOrDefaultAsync(); 
			}
			return result;
		}
	}
}
