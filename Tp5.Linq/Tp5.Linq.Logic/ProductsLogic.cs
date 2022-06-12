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
    public class ProductsLogic : BaseLogic
    {
        public ProductsLogic()
        {
        }

        public ProductsLogic(NorthwindContext context) : base(context)
        {
        }

        public List<Products> ObtenerProductosSinStock()
        {
            // 2.Query para devolver todos los productos sin stock
            return _context.Products.Where(p => p.UnitsInStock == 0).ToList();
        }

        public List<Products> ObtenerProductosConStockYCuestanMasPrecio(decimal precio)
        {
            // 3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad
            return (from product in _context.Products
                    where product.UnitsInStock > 0 && product.UnitPrice > precio
                    select product).ToList();
        }

        public Products Obtener(int id)
        {
            // 5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789
            return _context.Products.Where(p => p.ProductID == id).FirstOrDefault();
        }

        public List<Products> ObtenerProductosOrdenadoPorNombre()
        {
            // 9. Query para devolver lista de productos ordenados por nombre
            return (from product in _context.Products
                    orderby product.ProductName
                    select product).ToList();
        }

        public List<Products> ObtenerProductosOrdenadoPorUnidadPrecioMayorAMenor()
        {
            // 10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.
            return _context.Products.OrderByDescending(p => p.UnitPrice).ToList();
        }

        public List<ProductsDTO> ObtenerCategoriasDeProductosAsociadas()
        {
            // 11. Query para devolver las distintas categorías asociadas a los productos
            var query =
                (from product in _context.Products
                 join category in _context.Categories on product.CategoryID equals category.CategoryID
                 select new ProductsDTO { CategoryID = category.CategoryID, CategoryName = category.CategoryName }).Distinct();
            return query.ToList();
        }

        public Products ObtenerPrimerProducto()
        {
            // 12. Query para devolver el primer elemento de una lista de productos
            return (from product in _context.Products
                    select product).First();
        }
    }
}
