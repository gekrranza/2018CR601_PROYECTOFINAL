using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2018CR601.Models
{
	public class mascota
	{
		[Key]
		public int id_mascota { get; set; }
		public string nombre { get; set; }
		public string color { get; set; }
		public string sexo { get; set; }
		public int edad { get; set; }
	}
}
