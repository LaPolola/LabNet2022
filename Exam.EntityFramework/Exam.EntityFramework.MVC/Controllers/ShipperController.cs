using Exam.EntityFramework.Entities;
using Exam.EntityFramework.Logic;
using Exam.EntityFramework.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.EntityFramework.MVC.Controllers
{
    public class ShipperController : Controller
    {
        ILogic<Shippers> shipperLogic = new ShippersLogic();

        // GET: Shipper
        public ActionResult Index()
        {
            List<Shippers> shippers = shipperLogic.GetAll();
            List<ShipperView> shippersViews = shippers.Select(s => new ShipperView
            {
                Id = s.ShipperID,
                Name = s.CompanyName
            }).ToList();
            return View(shippersViews);
        }

        public ActionResult InsertUpdate(int id = 0)
        {
            ShipperView shipperView = null;
            if (id > 0)
            {
                Shippers shipperEntity = shipperLogic.Get(id);
                shipperView = new ShipperView();
                shipperView.Id = shipperEntity.ShipperID;
                shipperView.Name = shipperEntity.CompanyName;
            }
            return View(shipperView);
        }

        [HttpPost]
        public ActionResult InsertUpdate(ShipperView shipperView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (shipperView.Id == 0)
                    {
                        Shippers shipperEntity = new Shippers
                        {
                            CompanyName = shipperView.Name
                        };
                        shipperLogic.Add(shipperEntity);
                    }
                    else
                    {
                        Shippers shipperEntity = shipperLogic.Get(shipperView.Id);
                        shipperEntity.CompanyName = shipperView.Name;
                        shipperLogic.Update(shipperEntity);
                    }
                    return RedirectToAction("Index");
                }

                return View(shipperView);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public JsonResult delete(int id = 0)
        {
            bool ok = false;
            string message = "";

            if (id == 0)
            {
                message = "Debe seleccionar el transporte que desea eliminar";
            }
            else
            {
                try
                {
                    shipperLogic.Delete(id);
                    ok = true;
                    message = "El transporte se ha eliminado correctamente";
                }
                catch (System.FormatException e)
                {
                    message = "\nNo se pudo eliminar el transporte. \nMotivo: seguro ingreso una letra o no ingreso nada";
                }
                catch (System.ArgumentNullException)
                {
                    message = "\nNo se pudo eliminar el transporte. \nMotivo: no se encontró ningún transporte con el ID ingresado";
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    message = "\nNo se pudo eliminar el transporte. \nMotivo: el transporte que desea eliminar está siendo utilizado como referencia.";
                }
            }

            return Json(new { ok = ok, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}