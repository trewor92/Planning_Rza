using Microsoft.EntityFrameworkCore;
using PlanningRZA.Models;
using PlanningRZA.Models.Equipments;
using System;

namespace PlanningRZA.DBRepository
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
		{
		}
		public DbSet<Branch> Branches { get; set; }
		public DbSet<Substation> Substations { get; set; }
		public DbSet<Equipment> Equipments { get; set; }
		public DbSet<Transformer> Transformers { get; set; }
		public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
		public DbSet<VoltageTransformer> VoltageTransformers { get; set; }
		public DbSet<Breaker> Breakers { get; set; }
	}
}
