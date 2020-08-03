using PlanningRZA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRZA.DBRepository.Interfaces
{
	public interface ISubstationRepository
	{
		Task<List<Substation>> GetAllSubstations(bool deep=false);
		Task<Substation> GetSubstation(int substationId, bool deep=false);
		Task AddSubstation(Substation substation);
		Task EditSubstation(Substation substation, int substationId);
		Task DeleteSubstation(int substationId);
	}
}

