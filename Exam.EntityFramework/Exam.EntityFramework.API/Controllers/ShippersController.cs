using Exam.EntityFramework.API.Models.Dto;
using Exam.EntityFramework.Entities;
using Exam.EntityFramework.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Exam.EntityFramework.API.Controllers
{
    [EnableCors(origins: "https://localhost:44337,http://localhost:4200", headers: "*", methods: "*")]
    public class ShippersController : ApiController
    {
        private readonly ILogic<Shippers> shipperLogic;

        public ShippersController()
        {
            this.shipperLogic = new ShippersLogic(); ;
        }

        public ShippersController(ILogic<Shippers> shipperLogic)
        {
            this.shipperLogic = shipperLogic;
        }

        // GET: Shippers
        /// <summary>
        /// Listado de Shippers
        /// </summary>
        /// <remarks>
        /// Listado de Shippers
        /// </remarks>
        /// <returns></returns>
        public IHttpActionResult GetShippers()
        {
            try
            {
                var shippers = shipperLogic.GetAll();
                var shippersViews = shippers.Select(s => new ShipperDto
                {
                    Id = s.ShipperID,
                    Name = s.CompanyName
                }).ToList();

                if (shippersViews == null)
                {
                    return NotFound();
                }

                return Ok(shippersViews);
            }
            catch (Exception e)
            {
                return BadRequest("Ocurrió un error. \nMotivo: " + e.Message);
            }
        }

        // GET: Shippers/{id}
        /// <summary>
        /// Obtener Shipper por Id
        /// </summary>
        /// <remarks>
        /// Obtener Shipper por Id
        /// </remarks>
        /// <param name="id">Id del Elemento por Route Param</param>
        /// <returns></returns>
        public IHttpActionResult GetShippers(int id)
        {
            try
            {
                Shippers shipper = shipperLogic.Get(id);
                if (shipper == null)
                {
                    return NotFound();
                }
                var shippersViews = new ShipperDto
                {
                    Id = shipper.ShipperID,
                    Name = shipper.CompanyName
                };

                return Ok(shippersViews);
            }
            catch (Exception e)
            {
                return BadRequest("Ocurrió un error. \nMotivo: " + e.Message);
            }
        }

        // POST: Shippers
        /// <summary>
        /// Crear un Shipper
        /// </summary>
        /// <remarks>
        /// Crear un Shipper
        /// </remarks>
        /// <param name="shipperRequest">Json From body</param>
        /// <returns></returns>
        public IHttpActionResult PostShippers(ShipperDto shipper)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Shippers shipperEntity = new Shippers
                    {
                        CompanyName = shipper.Name
                    };
                    shipperLogic.Add(shipperEntity);
                    return Ok(shipperEntity);
                }

                return BadRequest("Ocurrió un error. \nMotivo: " + ModelState.ToString());
            }
            catch (Exception e)
            {
                return BadRequest("Ocurrió un error. \nMotivo: " + e.Message);
            }
        }

        // PUT: Shippers
        /// <summary>
        /// Editar un Shipper
        /// </summary>
        /// <remarks>
        /// Editar un Shipper
        /// </remarks>
        /// <param name="shipperRequest">Json From body</param>
        /// <returns></returns>
        public IHttpActionResult PutShippers(ShipperDto shipper)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Shippers shipperEntity = shipperLogic.Get(shipper.Id);
                    if (shipperEntity == null)
                    {
                        return NotFound();
                    }
                    shipperEntity.CompanyName = shipper.Name;
                    shipperLogic.Update(shipperEntity);
                    return Ok(shipperEntity);

                }

                return BadRequest("Ocurrió un error. \nMotivo: " + ModelState.ToString());
            }
            catch (Exception e)
            {
                return BadRequest("Ocurrió un error. \nMotivo: " + e.Message);
            }
        }

        // DELETE: Shippers/{id}
        /// <summary>
        /// Eliminar un Shipper por Id
        /// </summary>
        /// <remarks>
        /// Eliminar un Shipper por Id
        /// </remarks>
        /// <param name="id">Id del Elemento por Route Param</param>
        /// <returns></returns>
        public IHttpActionResult DeleteShippers(int id)
        {
            try
            {
                shipperLogic.Delete(id);
                return Ok("El transporte se ha eliminado correctamente");
            }
            catch (System.FormatException e)
            {
                return BadRequest("No se pudo eliminar el transporte. \nMotivo: seguro ingreso una letra o no ingreso nada. \nInfo: " + e.Message);
            }
            catch (System.ArgumentNullException)
            {
                return NotFound();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return BadRequest("No se pudo eliminar el transporte. \nMotivo: el transporte que desea eliminar está siendo utilizado como referencia. \nInfo: " + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Ocurrió un error. \nMotivo: " + e.Message);
            }
        }
    }
}