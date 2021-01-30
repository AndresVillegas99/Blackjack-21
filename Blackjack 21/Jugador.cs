using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Blackjack_21.Cartas;

namespace Blackjack_21
{
    public class Jugador
    {
        public  List<Cartas> mano = new List<Cartas>();
        public  int salir(List<Jugador> lista, int partida, Jugador j1)
        {

            Console.WriteLine("No seguiste con la ronda,saliste de la partida");
            lista.Remove(j1);
            partida = partida - 1;
            return partida;
        }

        
        public  void unaMas(Baraja Bar)
        {
            Cartas nueva = new Cartas();
            nueva = Bar.tomarCarta();
            mano.Add(nueva);
        }

        public void unaMasAce(Baraja Bar) {
            Cartas nueva = new Cartas();
            foreach (var car in Bar.baraja)
            {
                if (car.numero.ToString().Equals("As")) 
                {
                    nueva = car;
                    break;
                }
            }
            mano.Add(nueva);

        }
                
            

        public  int revisarCartas(int tot) {
            int total = 0;
            if (!mano.Any()) 
            {
                Console.WriteLine("mano vacia");
            }
            
            foreach (var cartas in mano)
            {
                total = total + cartas.valor;
                tot = total;
            }

                foreach (var cartas in mano)
            {
                
                string numero = cartas.numero.ToString();
                string naipe = cartas.variedad.ToString();
                Console.Write(naipe + " " +numero + " ,");
                
                if (tot <= 11 &&  numero.Equals("As"))
                {
                    
                    tot = tot + cartas.valor + 9;
                }
              /*  else
                {
                    if (total > 11 && numero.Equals("As"))
                    {
                        tot = tot + cartas.valor  - 10;
                        
                    }
                }*/
                

            }
           
                Console.WriteLine("El total es " + tot);
            

            return tot;
        }

        public bool  espera(bool hold,int total ) 
        {
            Console.WriteLine("Usted ha decidodo esperar con un total de " + total);
            hold = true;
            return hold;
        }

        
    }
}
