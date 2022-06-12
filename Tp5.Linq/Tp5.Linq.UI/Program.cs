using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp5.Linq.UI
{
    internal class Program
    {
        private static CustomersUI customersUI;
        private static ProductsUI productsUI;

        static void Main(string[] args)
        {
            customersUI = new CustomersUI();
            productsUI = new ProductsUI();

            Console.WriteLine("TP N° 5");
            Console.WriteLine("____________________");

            Console.WriteLine("\nConsulta 1: Query para devolver objeto customer\n");
            customersUI.ObtenerClientes();

            Console.WriteLine("\nConsulta 2: Query para devolver todos los productos sin stock\n");
            productsUI.ObtenerProductosSinStock();

            Console.WriteLine("\nConsulta 3: Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad\n");
            productsUI.ObtenerProductosConStockYCuestanMasPrecio(3);

            Console.WriteLine("\nConsulta 4: Query para devolver todos los customers de la Región WA\n");
            customersUI.ObtenerClientesSegunRegion("WA");

            Console.WriteLine("\nConsulta 5: Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789\n");
            productsUI.Obtener(789);

            Console.WriteLine("\nConsulta 6: Query para devolver los nombre de los Customers. Mostrarlos en Mayúscula y en Minúscula.\n");
            Console.WriteLine("\nConsulta 6a: Customers en Mayúscula.\n");
            customersUI.ObtenerNombreClientesMinusculaOMayuscula(true);

            Console.WriteLine("\nConsulta 6b: Customers en Minúscula.\n");
            customersUI.ObtenerNombreClientesMinusculaOMayuscula();

            Console.WriteLine("\nConsulta 7: Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.\n");
            customersUI.ObtenerClientesPorRegionConOrdenesPorFecha("WA", new DateTime(1997, 1, 1));

            Console.WriteLine("Consultas no obligatorias");
            Console.WriteLine("__________________________________________");
            Console.WriteLine("\nConsulta 8: Query para devolver los primeros 3 Customers de la  Región WA\n");
            customersUI.ObtenerClientesSegunRegion("WA", 3);

            Console.WriteLine("\nConsulta 9:  Query para devolver lista de productos ordenados por nombre\n");
            productsUI.ObtenerProductosOrdenadoPorNombre();

            Console.WriteLine("\nConsulta 10: Query para devolver lista de productos ordenados por unit in stock de mayor a menor.\n");
            productsUI.ObtenerProductosOrdenadoPorUnidadPrecioMayorAMenor();

            Console.WriteLine("\nConsulta 11: Query para devolver las distintas categorías asociadas a los productos.\n");
            productsUI.ObtenerCategoriasDeProductosAsociadas();

            Console.WriteLine("\nConsulta 12: Query para devolver el primer elemento de una lista de productos\n");
            productsUI.ObtenerPrimerProducto();

            Console.WriteLine("\nConsulta 13: Query para devolver los customer con la cantidad de ordenes asociadas\n");
            customersUI.ObtenerClientesConCantidadDeOrdenesAsociadas();
        }
    }
}
