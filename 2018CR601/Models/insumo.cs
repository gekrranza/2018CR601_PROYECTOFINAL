using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace _2018CR601.Models
{
	public class insumo
	{
		[Key]
		public int id_insumo { get; set; }
		public string descripcion { get; set; }
		public int cantidad { get; set; }
		public string categoria { get; set; }
		public string id_proveedor { get; set; }
	}
}
