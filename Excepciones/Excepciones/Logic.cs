using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class Logic
    {
        public static void metodo1()
        {
            throw new NotImplementedException();
        }

        public static void metodo2()
        {
            throw new CustomException("Mensaje de Error de nuestra clase Custom Exception");
        }
    }
}
