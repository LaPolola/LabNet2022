using Exam.EntityFramework.Data;
using Exam.EntityFramework.Entities;
using Exam.EntityFramework.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ObtenerTodosLosProveedores()
        {
            // Aclaración: para realizar las pruebas se instalo con Nuget: Moq
            // Link documentación utilizada: https://docs.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking
            // Idea: supone que inicialmente la DB NorthWind esta cargada con datos en la tabla shippers y por lo tanto
            // se hace una consulta que traiga todos y luego se condiciona que la cantidad de shippers devuelta sea mayor a cero y que esto sea verdadero.

            var data = new List<Shippers>
            {
                new Shippers { CompanyName = "Speedy Express", Phone = "(503) 555-9831" },
                new Shippers { CompanyName = "United Package", Phone = "(503) 555-3199" },
                new Shippers { CompanyName = "Federal Shipping", Phone = "(503) 555-9931" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Shippers>>();
            mockSet.As<IQueryable<Shippers>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Shippers>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Shippers>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Shippers>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Shippers).Returns(mockSet.Object);

            ILogic<Shippers> shippersLogic = new ShippersLogic(mockContext.Object);
            Assert.IsTrue(shippersLogic.GetAll().Count > 0);
        }
    }
}
