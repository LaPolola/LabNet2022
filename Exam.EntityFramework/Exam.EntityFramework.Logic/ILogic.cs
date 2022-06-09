using Exam.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.EntityFramework.Logic
{
    public interface ILogic<T> where T : BaseEntity
    {
        List<T> GetAll();

        int Add(T obj);

        void Update(T obj);

        void Delete(int id);

        T Get(int id);
    }
}
