using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5.Linq.Entities;
using Tp5.Linq.Logic;

namespace Tp5.Linq.UI
{
    public class ProductsUI
    {
        private ProductsLogic productsLogic;

        public ProductsUI()
        {
            productsLogic = new ProductsLogic();
        }

        public void ObtenerProductosSinStock()
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item2 in productsLogic.ObtenerProductosSinStock())
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item2.ProductID, item2.ProductName, item2.UnitPrice, item2.UnitsInStock);
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void ObtenerProductosConStockYCuestanMasPrecio(decimal precio)
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item3 in productsLogic.ObtenerProductosConStockYCuestanMasPrecio(precio))
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item3.ProductID, item3.ProductName, item3.UnitPrice, item3.UnitsInStock);
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void Obtener(int id)
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            Products item5 = productsLogic.Obtener(id);

            if (item5 == null)
            {
                Console.WriteLine("No se encontró producto con ID: 789");
            }
            else
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item5.ProductID, item5.ProductName, item5.UnitPrice, item5.UnitsInStock);
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void ObtenerProductosOrdenadoPorNombre()
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item9 in productsLogic.ObtenerProductosOrdenadoPorNombre())
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item9.ProductID, item9.ProductName, item9.UnitPrice, item9.UnitsInStock);
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void ObtenerProductosOrdenadoPorUnidadPrecioMayorAMenor()
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item10 in productsLogic.ObtenerProductosOrdenadoPorUnidadPrecioMayorAMenor())
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item10.ProductID, item10.ProductName, item10.UnitPrice, item10.UnitsInStock);
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void ObtenerCategoriasDeProductosAsociadas()
        {
            Console.Write("{0,-10} {1,-35}", "ID", "Nombre de Categoría");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item11 in productsLogic.ObtenerCategoriasDeProductosAsociadas())
            {
                Console.WriteLine("{0,-10} {1,-35:N1}", item11.CategoryID, item11.CategoryName);
            }
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }

        public void ObtenerPrimerProducto()
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            var item12 = productsLogic.ObtenerPrimerProducto();
            Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item12.ProductID, item12.ProductName, item12.UnitPrice, item12.UnitsInStock);
            Console.WriteLine("\nPresionar Enter para pasar a la siguiente consulta");
            Console.ReadLine();
        }
    }
}
