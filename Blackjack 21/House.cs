using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackjack_21
{
    class House
    {
        private static List<Cartas> manoCasa = new List<Cartas>(); // Tiene basicamente los mismos metodos que jugador, pero sin mostrar en consola cartas o numeros

        public void unaMasCasa(Baraja Bar)
        {
            Cartas nueva = new Cartas();
            nueva = Bar.tomarCarta();
            manoCasa.Add(nueva);
        }

        public int revisarCartasCasa(int tot)
        {
            int total = 0;
            if (!manoCasa.Any())
            {
                Console.WriteLine("mano vacia");
            }

            foreach (var cartas in manoCasa)
            {
                total = total + cartas.valor;
                tot = total;
            }

            foreach (var cartas in manoCasa)
            {

                string numero = cartas.numero.ToString();
                

                if (total <= 21 && numero.Equals("As"))
                {

                    total = total + cartas.valor + 10;
                }
                else
                {
                    if (total >= 21 && numero.Equals("As"))
                    {
                        total = total + cartas.valor - 11;

                    }
                }


            }

           


            return tot;
        }
    }
}
