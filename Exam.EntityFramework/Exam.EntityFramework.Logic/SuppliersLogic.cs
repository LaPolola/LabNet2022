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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Suppliers Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public void Update(Suppliers newSupplier)
        {
            throw new NotImplementedException();
        }
    }
}
