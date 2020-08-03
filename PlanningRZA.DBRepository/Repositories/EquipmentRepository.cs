using PlanningRZA.DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using PlanningRZA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningRZA.Models.Equipments;

namespace PlanningRZA.DBRepository.Repositories
{
	public class EquipmentRepository : BaseRepository, IEquipmentRepository
	{
		public EquipmentRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

		public Task AddEquipment(Equipment equipment)
		{
			throw new NotImplementedException();
		}
		
		public Task DeleteEquipment(int equipmentId)
		{
			throw new NotImplementedException();
		}

		public Task EditEquipment(Equipment equipment, int equipmentId)
		{
			throw new NotImplementedException();
		}
		
		public async Task<List<Equipment>> GetAllEquipments()
		{
			List<Equipment> result;
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				var query = context.Equipments.AsQueryable();
				result = await query.ToListAsync();
			}
			return result;
		}

		public async Task<Equipment> GetEquipment(int equipmentId)
		{
			Equipment result;
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				var query = context.Equipments.AsQueryable();
				query = query.Where(b => b.Id == equipmentId);
				result = await query.FirstOrDefaultAsync();
			}
			return result;
		}
	}
}
