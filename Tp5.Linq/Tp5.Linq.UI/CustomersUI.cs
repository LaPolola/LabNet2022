using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5.Linq.Logic;

namespace Tp5.Linq.UI
{
    public class CustomersUI
    {
        private static CustomersLogic customersLogic;

        public CustomersUI()
        {
            customersLogic = new CustomersLogic();
        }

        public void ObtenerClientes()
        {
            Console.Write("{0,-10} {1,-30} {2,-15}", "ID", "Nombre de Contacto", "Región");
            Console.WriteLine("\n____________________________________________________\n");
            foreach (var item1 in customersLogic.ObtenerClientes())
            {
                Console.WriteLine("{0,-10} {1,-30:N1} {2,-15:N1}", item1.CustomerID, item1.ContactName, item1.Region);
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void ObtenerClientesSegunRegion(string region)
        {
            Console.Write("{0,-10} {1,-30} {2,-15}", "ID", "Nombre de Contacto", "Región");
            Console.WriteLine("\n____________________________________________________\n");
            foreach (var item4 in customersLogic.ObtenerClientesSegunRegion(region))
            {
                Console.WriteLine("{0,-10} {1,-30:N1} {2,-15:N1}", item4.CustomerID, item4.ContactName, item4.Region);
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void ObtenerNombreClientesMinusculaOMayuscula(bool convertirMayuscula = false)
        {
            Console.Write("{0,-10} {1,-30} {2,-15}", "ID", "Nombre de Contacto", "Región");
            Console.WriteLine("\n____________________________________________________\n");
            foreach (var item6a in customersLogic.ObtenerNombreClientesMinusculaOMayuscula(convertirMayuscula))
            {
                Console.WriteLine("{0,-10} {1,-30:N1} {2,-15:N1}", item6a.CustomerID, item6a.ContactName, item6a.Region);
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void ObtenerClientesPorRegionConOrdenesPorFecha(string region, DateTime ordenFecha)
        {
            Console.Write("{0,-10} {1,-30} {2,-15} {3,-15}", "ID", "Nombre de Contacto", "Región", "Fecha de Orden");
            Console.WriteLine("\n____________________________________________________________________________________\n");
            var query = customersLogic.ObtenerClientesPorRegionConOrdenesPorFecha(region, ordenFecha);
            if (query.Count == 0)
            {
                Console.WriteLine("No hay Ordenes de Clientes de la Región: WA en la Fecha: 01/01/1997");
            }
            else
            {
                foreach (var item7 in query)
                {
                    Console.WriteLine("{0,-10} {1,-30:N1} {2,-15:N1} {3,-15}", item7.CustomerID, item7.ContactName, item7.Region, item7.OrderDate);
                }
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void ObtenerClientesSegunRegion(string region, int limit)
        {
            Console.Write("{0,-10} {1,-30} {2,-15}", "ID", "Nombre de Contacto", "Región");
            Console.WriteLine("\n____________________________________________________\n");
            foreach (var item8 in customersLogic.ObtenerClientesSegunRegion("WA", 3))
            {
                Console.WriteLine("{0,-10} {1,-30:N1} {2,-15:N1}", item8.CustomerID, item8.ContactName, item8.Region);
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void ObtenerClientesConCantidadDeOrdenesAsociadas()
        {
            Console.Write("{0,-10} {1,-35} {2,-15}", "ID", "Nombre de Contacto", "Cantidad de Ordenes");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item13 in customersLogic.ObtenerClientesConCantidadDeOrdenesAsociadas())
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15}", item13.CustomerID, item13.ContactName, item13.CountOrders);
            }
            Console.WriteLine("\nMuchas gracias por realizar las pruebas. Espero sus feedbacks!!! ^_^.");
            Console.ReadLine();
        }
    }
}
