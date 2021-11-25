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
	public class adoptanteController : ControllerBase
	{
		private readonly albergueContext _contexto;

		public adoptanteController(albergueContext miContexto)
		{
			this._contexto = miContexto;
		}

		//Metodo para consultar adoptante
		[HttpGet]
		[Route("api/adoptante")]
		public IActionResult Get()
		{
			IEnumerable<adoptante> adoList = from a in _contexto.adoptante
											select a;
			if (adoList.Count() > 0)
			{
				return Ok(adoList);
			}
			return NotFound();
		}
		//Método para insertar adoptante
		[HttpPost]
		[Route("api/adoptante")]
		public IActionResult guardarAdoptante([FromBody] adoptante adoptanteNuevo)
		{
			try
			{
				IEnumerable<adoptante> adoptanteExiste = from a in _contexto.adoptante
													 where a.nombre == adoptanteNuevo.nombre

													 select a;
				if (adoptanteExiste.Count() == 0)
				{
					_contexto.adoptante.Add(adoptanteNuevo);
					_contexto.SaveChanges();
					return Ok(adoptanteNuevo);
				}
				return Ok(adoptanteExiste);
			}
			catch (System.Exception)
			{
				return BadRequest();
			}
		}
		//Método para modificar adoptante
		[HttpPut]
		[Route("api/adoptante")]
		public IActionResult updateAdoptante([FromBody] adoptante adoptanteAModificar)
		{
			adoptante adoptanteExiste = (from a in _contexto.adoptante
									where a.id_adop == adoptanteAModificar.id_adop
									select a).FirstOrDefault();
			if (adoptanteExiste is null)
			{
				return NotFound();
			}

			adoptanteExiste.nombre = adoptanteAModificar.nombre;
			adoptanteExiste.apellido = adoptanteAModificar.apellido;
			adoptanteExiste.direccion = adoptanteAModificar.direccion;
			adoptanteExiste.telefono = adoptanteAModificar.telefono;

			_contexto.Entry(adoptanteExiste).State = EntityState.Modified;
			_contexto.SaveChanges();

			return Ok(adoptanteExiste);

		}

	}
}
