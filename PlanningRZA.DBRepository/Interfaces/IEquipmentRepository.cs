using PlanningRZA.Models;
using PlanningRZA.Models.Equipments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRZA.DBRepository.Interfaces
{
	public interface IEquipmentRepository
	{
		Task<List<Equipment>> GetAllEquipments();
		Task<Equipment> GetEquipment(int equipmentId);
		Task AddEquipment(Equipment equipment);
		Task EditEquipment(Equipment equipment, int equipmentId);
		Task DeleteEquipment(int equipmentId);
	}
}
