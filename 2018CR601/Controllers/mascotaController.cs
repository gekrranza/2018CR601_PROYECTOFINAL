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
	public class mascotaController : ControllerBase
	{
		private readonly albergueContext _contexto;

		public mascotaController(albergueContext miContexto)
		{
			this._contexto = miContexto;
		}

		//Metodo para consultar mascotas
		[HttpGet]
		[Route("api/mascota")]
		public IActionResult Get(){
			IEnumerable<mascota> mascList = from m in _contexto.Mascota
											   select m;
			if (mascList.Count() > 0)
			{
				return Ok(mascList);
			}
			return NotFound();
		}
		//Método para insertar mascota
		[HttpPost]
		[Route("api/mascota")]
		public IActionResult guardarMascota([FromBody] mascota mascotaNueva)
		{
			try
			{
				IEnumerable<mascota> mascotaExiste = from m in _contexto.Mascota
													where m.nombre == mascotaNueva.nombre

													select m;
				if (mascotaExiste.Count() == 0)
				{
					_contexto.Mascota.Add(mascotaNueva);
					_contexto.SaveChanges();
					return Ok(mascotaNueva);
				}
				return Ok(mascotaExiste);
			}
			catch (System.Exception)
			{
				return BadRequest();
			}
		}

	}
}
