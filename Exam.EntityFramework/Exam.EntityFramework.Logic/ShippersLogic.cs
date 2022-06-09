using Exam.EntityFramework.Data;
using Exam.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.EntityFramework.Logic
{
    public class ShippersLogic : BaseLogic, ILogic<Shippers>
    {
        public ShippersLogic()
        {
        }
        public ShippersLogic(NorthwindContext context) : base(context)
        {
        }

        public int Add(Shippers newShippers)
        {
            _context.Shippers.Add(newShippers);
            _context.SaveChanges();
            return newShippers.ShipperID;
        }

        public void Delete(int id)
        {
            var shippersEliminar = _context.Shippers.Find(id);
            _context.Shippers.Remove(shippersEliminar);
            _context.SaveChanges();
        }

        public Shippers Get(int id)
        {
            return _context.Shippers.Find(id);
        }

        public List<Shippers> GetAll()
        {
            return _context.Shippers.ToList();
        }

        public void Update(Shippers newShippers)
        {
            var shippersUpdate = _context.Shippers.Find(newShippers.ShipperID);
            shippersUpdate.Phone = newShippers.Phone;
            shippersUpdate.CompanyName = newShippers.CompanyName;
            _context.SaveChanges();
        }
    }
}
