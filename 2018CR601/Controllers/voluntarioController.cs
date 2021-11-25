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
	public class voluntarioController : ControllerBase
	{
		private readonly albergueContext _contexto;

		public voluntarioController(albergueContext miContexto)
		{
			this._contexto = miContexto;
		}

		//Metodo para consultar voluntario
		[HttpGet]
		[Route("api/voluntario")]
		public IActionResult Get()
		{
			IEnumerable<voluntario> volList = from v in _contexto.voluntario
											 select v;
			if (volList.Count() > 0)
			{
				return Ok(volList);
			}
			return NotFound();
		}
		//Método para insertar voluntario
		[HttpPost]
		[Route("api/voluntario")]
		public IActionResult guardarVoluntario([FromBody] voluntario volNuevo)
		{
			try
			{
				IEnumerable<voluntario> volExiste = from v in _contexto.voluntario
												   where v.id_volu == volNuevo.id_volu

												   select v;
				if (volExiste.Count() == 0)
				{
					_contexto.voluntario.Add(volNuevo);
					_contexto.SaveChanges();
					return Ok(volNuevo);
				}
				return Ok(volExiste);
			}
			catch (System.Exception)
			{
				return BadRequest();
			}
		}
		//Método para modificar voluntario
		[HttpPut]
		[Route("api/voluntario")]
		public IActionResult updateVoluntario([FromBody] voluntario volAModificar)
		{
			voluntario volExiste = (from v in _contexto.voluntario
								   where v.id_volu == volAModificar.id_volu
								   select v).FirstOrDefault();
			if (volExiste is null)
			{
				return NotFound();
			}

			volExiste.nombre = volAModificar.nombre;
			volExiste.apellido = volAModificar.apellido;
			volExiste.direccion = volAModificar.direccion;
			volExiste.telefono = volAModificar.telefono;


			_contexto.Entry(volExiste).State = EntityState.Modified;
			_contexto.SaveChanges();

			return Ok(volExiste);

		}

		//Método para eliminar proveedor
		[HttpDelete]
		[Route("api/voluntario")]
		public IActionResult deleteVoluntario([FromBody] voluntario volAEliminar)
		{
			voluntario volExiste = (from v in _contexto.voluntario
								   where v.id_volu == volAEliminar.id_volu
								   select v).FirstOrDefault();
			if (volExiste is null)
			{
				return NotFound();
			}

			volExiste.nombre = volAEliminar.nombre;
			volExiste.apellido = volAEliminar.apellido;
			volExiste.direccion = volAEliminar.direccion;
			volExiste.telefono = volAEliminar.telefono;


			_contexto.Entry(volExiste).State = EntityState.Deleted;
			_contexto.SaveChanges();

			return Ok(volExiste);

		}
	}
}
