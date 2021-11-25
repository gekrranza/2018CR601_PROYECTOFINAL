using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace _2018CR601.Models
{
	public class cita_paseo
	{
		[Key]
		public int id_cita { get; set; }
		public int id_volu { get; set; }
		public int id_mascota { get; set; }
		public DateTime fecha { get; set; }
		
	}
}
