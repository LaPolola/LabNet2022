using Exam.EntityFramework.Entities;
using Exam.EntityFramework.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.EntityFramework.UI
{
    internal class ShippersUI : IBaseUI
    {
        private Shippers SolicitarDatosProveedor()
        {
            bool continuarNombreCompania = true;
            string companyName;
            do
            {
                Console.WriteLine("Ingresar nombre de compañía *");
                companyName = Console.ReadLine();
                if (companyName == "")
                {

                    Console.WriteLine("Advertencia: Debe ingresar un nombre de compañía.");
                }
                else
                {
                    continuarNombreCompania = false;
                }
            } while (continuarNombreCompania);

            bool continuarTelefono = true;
            string tel = null;
            do
            {
                Console.WriteLine("\nIngresar teléfono (opcional)");
                Console.WriteLine("\nAclaración: en caso de ingresar el tel. deben ser solo 10 números");
                tel = Console.ReadLine();

                long telefonoIngresado;
                if (tel != "")
                {
                    if (long.TryParse(tel, out telefonoIngresado))
                    {
                        if (tel.Length == 10)
                        {
                            tel = String.Format("{0:(###) ###-####}", telefonoIngresado);
                            continuarTelefono = false;
                        }
                        else
                        {
                            Console.WriteLine("\nAdvertencia: Debe ingresar 10 números.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nAdvertencia: Debe ingresar números.");
                    }
                }
                else
                {
                    tel = null;
                    continuarTelefono = false;
                }
            } while (continuarTelefono);

            return new Shippers
            {
                CompanyName = companyName,
                Phone = tel
            };
        }

        public void Agregar()
        {
            ShippersLogic shippersLogic = new ShippersLogic();
            shippersLogic.Add(SolicitarDatosProveedor());
        }

        public void Eliminar()
        {
            Console.WriteLine("\nLista de Transportes");
            VerLista();
            bool continuarEliminacion = true;
            int shipperId;
            do
            {
                try
                {
                    Console.WriteLine("\nIngresar ID de transporte que desea eliminar");
                    shipperId = int.Parse(Console.ReadLine());
                    ShippersLogic shippersLogic = new ShippersLogic();
                    shippersLogic.Delete(shipperId);
                    continuarEliminacion = false;
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("\nNo se pudo eliminar el transporte. \nMotivo: seguro ingreso una letra o no ingreso nada");
                }
                catch (System.ArgumentNullException)
                {
                    Console.WriteLine("\nNo se pudo eliminar el transporte. \nMotivo: no se encontró ningún transporte con el ID ingresado");
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    Console.WriteLine("\nNo se pudo eliminar el transporte. \nMotivo: el transporte que desea eliminar está siendo utilizado como referencia.");
                }
            } while (continuarEliminacion);
        }

        public void Modificar()
        {
            Console.WriteLine("\nLista de Transportes");
            VerLista();
            bool continuarModicicacion = true;
            int shipperId;
            do
            {
                try
                {
                    Console.WriteLine("\nIngresar ID de transporte que desea modificar");
                    shipperId = int.Parse(Console.ReadLine());
                    ShippersLogic shippersLogic = new ShippersLogic();
                    Shippers shipper = shippersLogic.Get(shipperId);
                    if (shipper == null)
                    {
                        Console.WriteLine("\nEl ID ingresado no corresponde a ningún transporte. Por favor vuelva a ingresar un ID");
                    }
                    else
                    {
                        shipper = SolicitarDatosProveedor();
                        shipper.ShipperID = shipperId;
                        shippersLogic.Update(shipper);
                        continuarModicicacion = false;
                    }
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("\nNo se pudo modificar el transporte. \nMotivo: seguro ingreso una letra o no ingreso nada");
                }
                catch (System.ArgumentNullException)
                {
                    Console.WriteLine("\nNo se pudo modificar el transporte. \nMotivo: no se encontró ningún transporte con el ID ingresado");
                }
            } while (continuarModicicacion);
        }

        public void VerLista()
        {
            ILogic<Shippers> shippersLogic = new ShippersLogic();

            Console.WriteLine("{0,-10} {1,-20} {2,-15}\n", "ID", "Compañía", "Teléfono");
            foreach (var item in shippersLogic.GetAll())
            {
                Console.WriteLine("{0,-10} {1,-20:N1} {2,-15:N1}", item.ShipperID, item.CompanyName, item.Phone);
            }
        }
    }
}
