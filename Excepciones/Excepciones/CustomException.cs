using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excepciones { 
    public class CustomException : Exception
    {
        //static int i, j;

        public CustomException() : base()
        {
        }

        public CustomException(String message) : base(message)
        {
        }

    }
}
