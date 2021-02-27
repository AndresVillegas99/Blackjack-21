using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_21
{
    class Modos
    {
        
<<<<<<< HEAD
        //Even 21
        //Cartas As + Pares.
        public Baraja Even21(Baraja Bar){ 
            foreach(Cartas item in Bar.baraja)
            {
                if (item.valor < 1 && item.valor / 2 == 0)
                {
                    Bar.baraja.Remove(item);

                }
            }
            return Bar;

        }

        //Light 21
        //Cartas Del As al 5
        public Baraja Light21(Baraja Bar)
        {
            foreach (Cartas item in Bar.baraja)
            {
                if (item.valor > 1 && item.valor < 5)
                {
                    Bar.baraja.Remove(item);

                }
            }
            return Bar;

=======
        public Baraja Killer21(Baraja Bar)
        {
            foreach (Cartas item in Bar.baraja)
            {
                if (item.valor>1 && item.valor< 6)
                {
                    Bar.baraja.Remove(item);
                }
            }
            return Bar;
        }

        public Baraja Odd21(Baraja Bar)
        {
            foreach (Cartas item in Bar.baraja)
            {
                if (item.valor % 2 == 0)
                {
                    Bar.baraja.Remove(item);
                }
            }
            return Bar;
>>>>>>> ddee79617b7942bc46afd8c16e8787cad7ee353e
        }
    }
}
