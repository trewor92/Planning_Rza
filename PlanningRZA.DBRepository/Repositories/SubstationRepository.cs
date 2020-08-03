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
	public class SubstationRepository : BaseRepository, ISubstationRepository
	{
		public SubstationRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

		public Task AddSubstation(Substation substation)
		{
			throw new NotImplementedException();
		}

		public Task DeleteSubstation(int substationId)
		{
			throw new NotImplementedException();
		}

		public Task EditSubstation(Substation substation, int substationId)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Substation>> GetAllSubstations(bool deep=false)
		{
			List<Substation> result;
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				var query = context.Substations.AsQueryable();

				if (deep)
					query = query.Include(b => b.Equipments);

				result = await query.ToListAsync();
			}
			return result;
		}

		public async Task<Substation> GetSubstation(int substationId, bool deep=false)
		{
			Substation result;
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				var query = context.Substations.AsQueryable();
				query = query.Where(b => b.Id == substationId);

				if (deep)
					query = query.Include(b => b.Equipments);

				result = await query.FirstOrDefaultAsync();
			}
			return result;
		}
	}
}
