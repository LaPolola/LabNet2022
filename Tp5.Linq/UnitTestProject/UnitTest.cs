using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tp5.Linq.Data;
using Tp5.Linq.Entities;
using Tp5.Linq.Logic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ObtenerClientes()
        {
            var data = new List<Customers>
            {
                new Customers { CustomerID = "ALFKI", ContactName = "Maria Anders", Region = "WA" },
                new Customers { CustomerID = "BERGS", ContactName = "Christina Berglund", Region = "BC" },
                new Customers { CustomerID = "CONSH", ContactName = "Consolidated Holdings", Region = "SP" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customers>>();
            mockSet.As<IQueryable<Customers>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Customers).Returns(mockSet.Object);

            CustomersLogic customersLogic = new CustomersLogic(mockContext.Object);

            var clientes = customersLogic.ObtenerClientes();

            Assert.AreEqual(3, clientes.Count);
            Assert.AreEqual("ALFKI", clientes[0].CustomerID);
            Assert.AreEqual("BERGS", clientes[1].CustomerID);
            Assert.AreEqual("CONSH", clientes[2].CustomerID);
        }

        [TestMethod]
        public void ObtenerProductosSinStock()
        {
            var data = new List<Products>
            {
                new Products { ProductID = 1, ProductName = "Chai", UnitPrice = 18.00M, UnitsInStock = 0 },
                new Products { ProductID = 2, ProductName = "Chang", UnitPrice = 19.00M, UnitsInStock = 17 },
                new Products { ProductID = 3, ProductName = "Aniseed Syrup", UnitPrice = 10.00M, UnitsInStock = 13 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Products>>();
            mockSet.As<IQueryable<Products>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Products>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Products>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Products>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            ProductsLogic productsLogic = new ProductsLogic(mockContext.Object);

            var productos = productsLogic.ObtenerProductosSinStock();

            Assert.AreEqual(1, productos.Count);
            Assert.AreEqual(1, productos[0].ProductID);
        }

        [TestMethod]
        public void ObtenerProductosConStockYCuestanMasPrecio3()
        {
            var data = new List<Products>
            {
                new Products { ProductID = 1, ProductName = "Chai", UnitPrice = 18.00M, UnitsInStock = 39 },
                new Products { ProductID = 2, ProductName = "Chang", UnitPrice = 19.00M, UnitsInStock = 17 },
                new Products { ProductID = 3, ProductName = "Aniseed Syrup", UnitPrice = 10.00M, UnitsInStock = 13 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Products>>();
            mockSet.As<IQueryable<Products>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Products>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Products>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Products>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            ProductsLogic productsLogic = new ProductsLogic(mockContext.Object);

            var productos = productsLogic.ObtenerProductosConStockYCuestanMasPrecio(3);

            Assert.AreEqual(3, productos.Count);
            Assert.AreEqual(1, productos[0].ProductID);
            Assert.AreEqual(2, productos[1].ProductID);
            Assert.AreEqual(3, productos[2].ProductID);
        }

        [TestMethod]
        public void ObtenerClientesSegunRegionWA()
        {
            var data = new List<Customers>
            {
                new Customers { CustomerID = "ALFKI", ContactName = "Maria Anders", Region = "WA" },
                new Customers { CustomerID = "BERGS", ContactName = "Christina Berglund", Region = "BC" },
                new Customers { CustomerID = "CONSH", ContactName = "Consolidated Holdings", Region = "SP" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customers>>();
            mockSet.As<IQueryable<Customers>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Customers).Returns(mockSet.Object);

            CustomersLogic customersLogic = new CustomersLogic(mockContext.Object);

            var clientes = customersLogic.ObtenerClientesSegunRegion("WA");

            Assert.AreEqual(1, clientes.Count);
            Assert.AreEqual("ALFKI", clientes[0].CustomerID);
        }


        [TestMethod]
        public void ObtenerProducto()
        {
            var data = new List<Products>
            {
                new Products { ProductID = 1, ProductName = "Chai", UnitPrice = 18.00M, UnitsInStock = 39 },
                new Products { ProductID = 2, ProductName = "Chang", UnitPrice = 19.00M, UnitsInStock = 17 },
                new Products { ProductID = 3, ProductName = "Aniseed Syrup", UnitPrice = 10.00M, UnitsInStock = 13 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Products>>();
            mockSet.As<IQueryable<Products>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Products>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Products>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Products>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            ProductsLogic productsLogic = new ProductsLogic(mockContext.Object);

            var producto = productsLogic.Obtener(1);

            Assert.AreEqual(1, producto.ProductID);
        }

        [TestMethod]
        public void ObtenerNombreClientesMinuscula()
        {
            var data = new List<Customers>
            {
                new Customers { CustomerID = "ALFKI", ContactName = "Maria Anders", Region = "WA" },
                new Customers { CustomerID = "BERGS", ContactName = "Christina Berglund", Region = "BC" },
                new Customers { CustomerID = "CONSH", ContactName = "Consolidated Holdings", Region = "SP" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customers>>();
            mockSet.As<IQueryable<Customers>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Customers).Returns(mockSet.Object);

            CustomersLogic customersLogic = new CustomersLogic(mockContext.Object);

            var clientes = customersLogic.ObtenerNombreClientesMinusculaOMayuscula();

            Assert.AreEqual(3, clientes.Count);
            Assert.AreEqual("maria anders", clientes[0].ContactName);
            Assert.AreEqual("christina berglund", clientes[1].ContactName);
            Assert.AreEqual("consolidated holdings", clientes[2].ContactName);
        }

        [TestMethod]
        public void ObtenerNombreClientesMayuscula()
        {
            var data = new List<Customers>
            {
                new Customers { CustomerID = "ALFKI", ContactName = "Maria Anders", Region = "WA" },
                new Customers { CustomerID = "BERGS", ContactName = "Christina Berglund", Region = "BC" },
                new Customers { CustomerID = "CONSH", ContactName = "Consolidated Holdings", Region = "SP" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customers>>();
            mockSet.As<IQueryable<Customers>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Customers).Returns(mockSet.Object);

            CustomersLogic customersLogic = new CustomersLogic(mockContext.Object);

            var clientes = customersLogic.ObtenerNombreClientesMinusculaOMayuscula(true);

            Assert.AreEqual(3, clientes.Count);
            Assert.AreEqual("MARIA ANDERS", clientes[0].ContactName);
            Assert.AreEqual("CHRISTINA BERGLUND", clientes[1].ContactName);
            Assert.AreEqual("CONSOLIDATED HOLDINGS", clientes[2].ContactName);
        }
    }
}
