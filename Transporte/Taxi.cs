using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporte
{
    public class Taxi : TransportePublico
    {
        public Taxi(int pasajeros, int numero) : base(pasajeros, numero)
        {

        }

        public override string Avanzar()
        {
            return "Avanzar de Taxi";
        }

        public override string Detenerse()
        {
            return "Detenerse de Taxi";
        }
    }
}
