using PlanningRZA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRZA.DBRepository.Interfaces
{
	public interface IBranchRepository
	{
		Task<List<Branch>> GetAllBranches(bool deep=false);
		Task<Branch> GetBranch(int branchId, bool deep=false);
		Task AddBranch(Branch branch);
		Task EditBranch(Branch branch, int branchId);
		Task DeleteBranch(int branchId);
	}
}