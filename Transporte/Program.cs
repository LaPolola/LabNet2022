using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporte
{
    class Program
    {
        static void Main(string[] args)
        {

            List<TransportePublico> Transportes = new List<TransportePublico>();
            int nro;
            for (int i = 0; i < 5; i++)
            {
                nro = i + 1;
                Console.WriteLine($"Ingresa la cantidad de pasajeros que vana viajar en el Omnibus {nro}");
                Omnibus omnibus = new Omnibus(int.Parse(Console.ReadLine()), nro);

                Transportes.Add(omnibus);
            }


            for (int i = 0; i < 5; i++)
            {
                nro = i + 1;
                Console.WriteLine($"Ingresa la cantidad de pasajeros que vana viajar en el Taxi {nro}");

                Taxi taxi = new Taxi(int.Parse(Console.ReadLine()), nro);

                Transportes.Add(taxi);
            }

            string transport = "";

            foreach (TransportePublico transporte in Transportes)
            {
                transport = transporte.GetType() == typeof(Transporte.Omnibus) ? "Omnibus" : "Taxi";
                Console.WriteLine($"{transport} {transporte.Numero}: {transporte.Pasajeros} pasajeros");
            }

            Console.ReadKey();

        }

       
    }
}
