using Excepciones;

namespace TestProjectException
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1_1()
        {
            // Test del Ejercicio 1
            // Probamos la divisi�n un caso com�n
            Decimal result = Excepciones.Program.dividir1(2, 2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestMethod1_2()
        {
            // Test del Ejercicio 1
            // Probamos el caso que nos arroje una excepci�n
            Action actual = () => Excepciones.Program.dividir1(2, 0);
            Assert.ThrowsException<DivideByZeroException>(actual);
        }

        [TestMethod]
        public void TestMethod2_1()
        {
            // Test del Ejercicio 2
            // Probamos la divisi�n un caso com�n
            Decimal result = Excepciones.Program.dividir1(2, 2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestMethod2_2()
        {
            // Test del Ejercicio 2
            // Probamos el caso que nos arroje una excepci�n
            Action actual = () => Excepciones.Program.dividir2(2, 0);
            Assert.ThrowsException<DivideByZeroException>(actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Test del Ejercicio 3
            // Probamos que nos arroje la excepcion
            Action actual = () => Excepciones.Logic.metodo1();
            Assert.ThrowsException<NotImplementedException>(actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Test del Ejercicio 4
            // Probamos que nos arroje la excepcion
            Action actual = () => Excepciones.Logic.metodo2();
            Assert.ThrowsException<CustomException>(actual);
        }
    }
}