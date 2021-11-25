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
	public class proveedorController : ControllerBase
	{
		private readonly albergueContext _contexto;

		public proveedorController(albergueContext miContexto)
		{
			this._contexto = miContexto;
		}

		//Metodo para consultar proveedor
		[HttpGet]
		[Route("api/proveedor")]
		public IActionResult Get()
		{
			IEnumerable<proveedor> proList = from p in _contexto.proveedor
										  select p;
			if (proList.Count() > 0)
			{
				return Ok(proList);
			}
			return NotFound();
		}
		//Método para insertar proveedor
		[HttpPost]
		[Route("api/proveedor")]
		public IActionResult guardarProveedor([FromBody] proveedor proveedorNuevo)
		{
			try
			{
				IEnumerable<proveedor> proExiste = from p in _contexto.proveedor
												where p.id_proveedor == proveedorNuevo.id_proveedor

												select p;
				if (proExiste.Count() == 0)
				{
					_contexto.proveedor.Add(proveedorNuevo);
					_contexto.SaveChanges();
					return Ok(proveedorNuevo);
				}
				return Ok(proExiste);
			}
			catch (System.Exception)
			{
				return BadRequest();
			}
		}
		//Método para modificar proveedor
		[HttpPut]
		[Route("api/proveedor")]
		public IActionResult updateProveedor([FromBody] proveedor proAModificar)
		{
			proveedor proExiste = (from p in _contexto.proveedor
								where p.id_proveedor == proAModificar.id_proveedor
								select p).FirstOrDefault();
			if (proExiste is null)
			{
				return NotFound();
			}

			proExiste.nombre = proAModificar.nombre;
			proExiste.direccion = proAModificar.direccion;
			proExiste.telefono = proAModificar.telefono;


			_contexto.Entry(proExiste).State = EntityState.Modified;
			_contexto.SaveChanges();

			return Ok(proExiste);

		}

		//Método para eliminar proveedor
		[HttpDelete]
		[Route("api/proveedor")]
		public IActionResult deleteProveedor([FromBody] proveedor proAEliminar)
		{
			proveedor proExiste = (from p in _contexto.proveedor
									where p.id_proveedor == proAEliminar.id_proveedor
									select p).FirstOrDefault();
			if (proExiste is null)
			{
				return NotFound();
			}

			proExiste.nombre = proAEliminar.nombre;
			proExiste.direccion = proAEliminar.direccion;
			proExiste.telefono = proAEliminar.telefono;


			_contexto.Entry(proExiste).State = EntityState.Deleted;
			_contexto.SaveChanges();

			return Ok(proExiste);

		}
	}
}
