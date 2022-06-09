using Exam.EntityFramework.Entities;
using Exam.EntityFramework.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.EntityFramework.UI
{
    internal class SuppliersUI : IBaseUI
    {
        public void Agregar()
        {
            throw new NotImplementedException();
        }

        public void Eliminar()
        {
            throw new NotImplementedException();
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }

        public void VerLista()
        {
            ILogic<Suppliers> suppliersLogic = new SuppliersLogic();

            Console.WriteLine("{0,-20} {1,-40} {2,-40} {3,-40} {4,-40}\n",
                "ID",
                "Compañía",
                "Contacto",
                "Título de contacto",
                "Ciudad");
            foreach (var item in suppliersLogic.GetAll())
            {
                Console.WriteLine("{0,-20} {1,-40} {2,-40} {3,-40} {4,-40}"
                    , item.SupplierID
                    , item.CompanyName
                    , item.ContactName
                    , item.ContactTitle
                    , item.City);
            }
        }
    }
}
