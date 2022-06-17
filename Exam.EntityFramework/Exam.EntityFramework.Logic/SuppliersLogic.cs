using Exam.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.EntityFramework.Logic
{
    public class SuppliersLogic : BaseLogic, ILogic<Suppliers>
    {
        public SuppliersLogic()
        {
        }

        public int Add(Suppliers newSupplier)
        {
            _context.Suppliers.Add(newSupplier);
            _context.SaveChanges();
            return newSupplier.SupplierID;
        }

        public void Delete(int id)
        {
            var suppliersEliminar = _context.Suppliers.Find(id);
            _context.Suppliers.Remove(suppliersEliminar);
            _context.SaveChanges();
        }

        public Suppliers Get(int id)
        {
            return _context.Suppliers.Where(s => s.SupplierID == id).FirstOrDefault();
        }

        public List<Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public void Update(Suppliers newSupplier)
        {
            var suppliersUpdate = _context.Suppliers.Find(newSupplier.SupplierID);
            suppliersUpdate.City = newSupplier.City;
            suppliersUpdate.Region = newSupplier.Region;
            suppliersUpdate.ContactTitle = newSupplier.ContactTitle;
            suppliersUpdate.PostalCode = newSupplier.PostalCode;
            suppliersUpdate.Country = newSupplier.Country;
            suppliersUpdate.Fax = newSupplier.Fax;
            suppliersUpdate.ContactName = newSupplier.ContactName;
            suppliersUpdate.HomePage = newSupplier.HomePage;
            suppliersUpdate.Address = newSupplier.Address;
            suppliersUpdate.Phone = newSupplier.Phone;
            suppliersUpdate.CompanyName = newSupplier.CompanyName;
            _context.SaveChanges();
        }
    }
}
