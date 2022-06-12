using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5.Linq.Data;
using Tp5.Linq.Entities;
using Tp5.Linq.Logic.DTO;

namespace Tp5.Linq.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public CustomersLogic()
        {
        }

        public CustomersLogic(NorthwindContext context) : base(context)
        {
        }

        public List<Customers> ObtenerClientes()
        {
            // 1. Query para devolver objeto customer
            return (
                from customer in _context.Customers
                select customer).ToList();
        }

        public List<Customers> ObtenerClientesSegunRegion(string region, int limit = 0)
        {
            // 4. Query para devolver todos los customers de la Región WA
            var query = _context.Customers.Where(c => c.Region == region);
            if (limit > 0)
            {
                // 8. Query para devolver los primeros 3 Customers de la  Región WA
                query.Take(limit);
            }
            return query.ToList();
        }

        public List<CustomersDTO> ObtenerNombreClientesMinusculaOMayuscula(bool convertirMayuscula = false)
        {
            // 6. Query para devolver los nombre de los Customers. Mostrarlos en Mayúscula y en Minúscula.
            var query = from customer in _context.Customers
                        select new CustomersDTO()
                        {
                            CustomerID = customer.CustomerID,
                            ContactName = convertirMayuscula ? customer.ContactName.ToUpper() : customer.ContactName.ToLower(),
                            Region = customer.Region
                        };

            return query.ToList();
        }

        public List<CustomersDTO> ObtenerClientesPorRegionConOrdenesPorFecha(string region, DateTime ordenFecha)
        {
            // 7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.
            var query = _context.Customers.Join(_context.Orders
                                        , c => c.CustomerID
                                        , o => o.CustomerID
                                        , (c, o) => new { c, o }
                                        ).Select(f => new CustomersDTO
                                        {
                                            CustomerID = f.c.CustomerID,
                                            ContactName = f.c.ContactName,
                                            Region = f.c.Region,
                                            OrderDate = f.o.RequiredDate
                                        }
                                        ).Where(z => z.Region == region && z.OrderDate == ordenFecha);

            return query.ToList();
        }

        public List<CustomersDTO> ObtenerClientesConCantidadDeOrdenesAsociadas()
        {
            // 13. Query para devolver los customer con la cantidad de ordenes asociadas
            var query =
                (from customer in _context.Customers
                 join order in _context.Orders on customer.CustomerID equals order.CustomerID
                 select new { customer.CustomerID, customer.ContactName, order.OrderID } into x
                 group x by new { x.CustomerID, x.ContactName } into g
                 select new CustomersDTO
                 {
                     CustomerID = g.Key.CustomerID,
                     ContactName = g.Key.ContactName,
                     CountOrders = g.Select(x => x.OrderID).Count()
                 });
            return query.ToList(); ;
        }
    }
}
