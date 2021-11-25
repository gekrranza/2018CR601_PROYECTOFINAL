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
	public class insumoController : ControllerBase
	{
		private readonly albergueContext _contexto;

		public insumoController(albergueContext miContexto)
		{
			this._contexto = miContexto;
		}

		//Metodo para consultar insumo
		[HttpGet]
		[Route("api/insumo")]
		public IActionResult Get()
		{
			IEnumerable<insumo> insList = from i in _contexto.insumo
											  select i;
			if (insList.Count() > 0)
			{
				return Ok(insList);
			}
			return NotFound();
		}
		//Método para insertar insumo
		[HttpPost]
		[Route("api/insumo")]
		public IActionResult guardarInsumo([FromBody] insumo insumoNuevo)
		{
			try
			{
				IEnumerable<insumo> insExiste = from i in _contexto.insumo
													 where i.id_insumo == insumoNuevo.id_insumo

													 select i;
				if (insExiste.Count() == 0)
				{
					_contexto.insumo.Add(insumoNuevo);
					_contexto.SaveChanges();
					return Ok(insumoNuevo);
				}
				return Ok(insExiste);
			}
			catch (System.Exception)
			{
				return BadRequest();
			}
		}
		//Método para modificar insumo
		[HttpPut]
		[Route("api/insumo")]
		public IActionResult updateInsumo([FromBody] insumo insAModificar)
		{
			insumo insExiste = (from i in _contexto.insumo
									 where i.id_insumo == insAModificar.id_insumo
									 select i).FirstOrDefault();
			if (insExiste is null)
			{
				return NotFound();
			}

			insExiste.descripcion = insAModificar.descripcion;
			insExiste.cantidad = insAModificar.cantidad;
			insExiste.categoria = insAModificar.categoria;


			_contexto.Entry(insExiste).State = EntityState.Modified;
			_contexto.SaveChanges();

			return Ok(insExiste);

		}

		//Método para eliminar proveedor
		[HttpDelete]
		[Route("api/insumo")]
		public IActionResult deleteInsumo([FromBody] insumo insAEliminar)
		{
			insumo insExiste = (from i in _contexto.insumo
									where i.id_insumo == insAEliminar.id_insumo
									select i).FirstOrDefault();
			if (insExiste is null)
			{
				return NotFound();
			}

			insExiste.descripcion = insAEliminar.descripcion;
			insExiste.cantidad = insAEliminar.cantidad;
			insExiste.categoria = insAEliminar.categoria;


			_contexto.Entry(insExiste).State = EntityState.Deleted;
			_contexto.SaveChanges();

			return Ok(insExiste);

		}
	}
}
