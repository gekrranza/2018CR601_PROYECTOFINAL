using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2018CR601.Models;

namespace _2018CR601.Controllers
{
	[ApiController]
	public class cita_adoptanteController : ControllerBase
	{
		private readonly albergueContext _contexto;

		public cita_adoptanteController(albergueContext miContexto)
		{
			this._contexto = miContexto;
		}

		//Metodo para consultar citas
		[HttpGet]
		[Route("api/cita")]
		public IActionResult Get()
		{
			IEnumerable<cita_paseo> citList = from c in _contexto.cita
											 select c;
			if (citList.Count() > 0)
			{
				return Ok(citList);
			}
			return NotFound();
		}
		//Método para insertar citas
		[HttpPost]
		[Route("api/cita")]
		public IActionResult guardarCita([FromBody] cita_paseo citaNueva)
		{
			try
			{
				IEnumerable<cita_paseo> citaExiste = from c in _contexto.cita
														 where c.id_cita == citaNueva.id_cita

														 select c;
				if (citaExiste.Count() == 0)
				{
					_contexto.cita.Add(citaNueva);
					_contexto.SaveChanges();
					return Ok(citaNueva);
				}
				return Ok(citaExiste);
			}
			catch (System.Exception)
			{
				return BadRequest();
			}
		}
		//Método para modificar citas
		[HttpPut]
		[Route("api/cita")]
		public IActionResult updateCita([FromBody] cita_paseo citaAModificar)
		{
			cita_paseo citaExiste = (from c in _contexto.cita
										 where c.id_cita == citaAModificar.id_cita
										 select c).FirstOrDefault();
			if (citaExiste is null)
			{
				return NotFound();
			}

			citaExiste.fecha = citaAModificar.fecha;

			_contexto.Entry(citaExiste).State = EntityState.Modified;
			_contexto.SaveChanges();

			return Ok(citaExiste);

		}

	}
}
