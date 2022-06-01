using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excepciones
{
    public class Program
    {
        /**
         * Ejercicio1. El método es llamado en el main.
         */
        public static decimal dividir1(decimal dividendo, decimal divisor)
        {
            try
            {
                return Decimal.Divide(dividendo, divisor);
            }
            finally
            {
                Console.WriteLine("Termino de realizarse la operación");
            }
        }

        /**
         * Ejercicio2
         */
        public static decimal dividir2(decimal dividendo, decimal divisor)
        {
            return Decimal.Divide(dividendo, divisor);
        }

        static void Main(string[] args)
        {
            // Ejercicio1 Start
            Console.WriteLine("Ejercicio 2.1");
            bool dividendoBandera = true;
            decimal dividendo = 0;
            do
            {
                Console.WriteLine("Ingresar dividendo");
                var resDividendo = Console.ReadLine();
                if (decimal.TryParse(resDividendo, out dividendo))
                {
                    dividendoBandera = false;
                }
                else
                {
                    Console.WriteLine("Ingreso un caracter o no ingreso nada. Debe ingresar un número para el dividendo");
                }
            } while (dividendoBandera);

            bool divisorBandera = true;
            decimal divisor = 0;
            do
            {
                Console.WriteLine("Ingresar divisor");
                var resDivisor = Console.ReadLine();
                if (decimal.TryParse(resDivisor, out divisor))
                {
                    divisorBandera = false;
                }
                else
                {
                    Console.WriteLine("Ingreso un caracter o no ingreso nada. Debe ingresar un número para el divisor");
                }
            } while (divisorBandera);

            try
            {
                Console.WriteLine("División: " + dividir1(dividendo, divisor));
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
            }
            // Ejercicio1 End

            // Ejercicio2 Start
            Console.WriteLine("Ejercicio 2.2");
            decimal dividendo2 = 0;
            bool dividendoBandera2 = true;
            do
            {
                try
                {
                    Console.WriteLine("Ingresar dividendo");
                    dividendo2 = decimal.Parse(Console.ReadLine());
                    dividendoBandera2 = false;
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!. Info Excepción: " + e);
                }
            } while (dividendoBandera2);

            decimal divisor2 = 0;
            bool divisorBandera2 = true;
            do
            {
                try
                {
                    Console.WriteLine("Ingresar divisor");
                    divisor2 = decimal.Parse(Console.ReadLine());
                    divisorBandera2 = false;
                } catch(System.FormatException e)
                {
                    Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!.Info Excepción: " + e);
                }
            } while (divisorBandera2);

            try
            {
                Console.WriteLine("División: " + dividir2(dividendo2, divisor2));
            } catch(DivideByZeroException e)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero!.Info Excepción: " + e);
            }
           
            // Ejercicio2 End

            // Ejercicio3 Start
            try
            {
                Console.WriteLine("Ejercicio 3");
                Logic.metodo1();
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine("El método no está implementado :p", e);
            }
            // Ejercicio3 Start

            // Ejercicio4 Start
            try
            {
                Console.WriteLine("Ejercicio 4");
                Logic.metodo2();
            }
            catch (CustomException e)
            {
                Console.WriteLine("Excepción customizada 😎", e);
            }
            // Ejercicio4 Start
            Console.ReadKey();
        }
    }
}
