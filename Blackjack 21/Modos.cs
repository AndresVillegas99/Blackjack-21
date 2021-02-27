using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_21
{
    class Modos
    {
        
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
        }
    }
}
