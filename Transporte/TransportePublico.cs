using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporte
{
    public abstract class TransportePublico
    {

        public int Numero { get; set; }
        public int Pasajeros { get; set; }

        //constructor
        public TransportePublico (int pasajeros, int numero)
        {
            Pasajeros = pasajeros;
            Numero = numero;
            
        }

        //métodos
        public abstract string Avanzar();

        public abstract string Detenerse();
    }
}
