using Exam.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.EntityFramework.UI
{
    internal class Program
    {
        private static SuppliersUI suppliersUI;
        private static ShippersUI shippersUI;
        private static bool continuar;
        private static int opcion;

        static void Main(string[] args)
        {
            continuar = true;
            suppliersUI = new SuppliersUI();
            shippersUI = new ShippersUI();
            do
            {
                Console.WriteLine("Menú principal");
                Console.WriteLine("__________________________\n");
                Console.WriteLine("1. Ver lista de Proveedores");
                Console.WriteLine("2. Ver lista de Transportes");
                Console.WriteLine("3. Agregar Transportes");
                Console.WriteLine("4. Modificar Transportes");
                Console.WriteLine("5. Eliminar Transportes");
                Console.WriteLine("6. Salir\n");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Opción seleccionada: 1. Ver lista de Proveedores\n");
                            suppliersUI.VerLista();
                            Console.WriteLine("\nPara regresar al menú principal presione Enter");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Opción seleccionada: 2. Ver lista de Transportes\n");
                            shippersUI.VerLista();
                            Console.WriteLine("\nPara regresar al menú principal presione Enter");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Opción seleccionada: 3. Agregar Transportes\n");
                            shippersUI.Agregar();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Opción seleccionada: 4. Modificar Transportes");
                            shippersUI.Modificar();
                            Console.Clear();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Opción seleccionada: 5. Eliminar Transportes");
                            shippersUI.Eliminar();
                            Console.Clear();
                            break;
                        case 6:
                            Console.Clear();
                            continuar = false;
                            Console.WriteLine("\nMuchas gracias por realizar las pruebas. Espero sus feedbacks!!! ^_^.");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("\nIngreso un opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nIngreso un carácter o no ingreso nada. Debe seleccionar una opción del menú para realizar una acción.");
                }
                Console.WriteLine();

            } while (continuar);
        }
    }
}
