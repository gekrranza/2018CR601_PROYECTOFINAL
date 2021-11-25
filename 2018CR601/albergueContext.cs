using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2018CR601.Models;
using Microsoft.EntityFrameworkCore.SqlServer;



namespace _2018CR601
{
	public class albergueContext: DbContext
	{
		public albergueContext(DbContextOptions<albergueContext> options) : base(options)
		{

		}
		public DbSet<mascota> Mascota { get; set; }
		public DbSet<adoptante> adoptante { get; set; }
		public DbSet<cita_paseo> cita { get; set; }
		public DbSet<insumo> insumo { get; set; }
		public DbSet<proveedor> proveedor { get; set; }
		public DbSet<voluntario> voluntario { get; set; }
	}
}
