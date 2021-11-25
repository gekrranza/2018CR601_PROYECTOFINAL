using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace _2018CR601.Models
{
	public class proveedor
	{
		[Key]
		public int id_proveedor { get; set; }
		public string nombre { get; set; }
		public string direccion { get; set; }
		public string telefono { get; set; }

	}
}
