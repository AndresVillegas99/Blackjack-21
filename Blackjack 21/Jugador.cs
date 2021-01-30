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

            Console.WriteLine("No seguiste con la ronda,saliste de la partida"); //Saca al jugador del juego
            lista.Remove(j1);
            partida = partida - 1;
            return partida;
        }

        
        public  void unaMas(Baraja Bar)
        {
            Cartas nueva = new Cartas();// saca una carta de la baraja y la pone en la mano del jugagor
            nueva = Bar.tomarCarta();
            mano.Add(nueva);
        }

        public void unaMasAce(Baraja Bar) {
            Cartas nueva = new Cartas();
            foreach (var car in Bar.baraja) //Se utilizo para porbar el As y sus cambios
            {
                if (car.numero.ToString().Equals("As")) 
                {
                    nueva = car;
                    break;
                }
            }
            mano.Add(nueva);

        }
                
            

        public  int revisarCartas(int tot) {   //Revisa la mano del jugador
            int total = 0; 
            if (!mano.Any()) 
            {
                Console.WriteLine("mano vacia");
            }
            
            foreach (var cartas in mano)
            {
                total = total + cartas.valor; //Suma el total de la mano del jugador y lo mete en la variable tot
                tot = total;
            }

                foreach (var cartas in mano)
            {
                
                string numero = cartas.numero.ToString(); //Convirte el numero de la carta para que se pueda leer
                string naipe = cartas.variedad.ToString(); //Convierte el tipo de naipe de la carta para que se pueda leer
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
           
                Console.WriteLine("El total es " + tot);  // dice el total de la carta
            

            return tot;
        }

        public bool  espera(bool hold,int total ) 
        {
            Console.WriteLine("Usted ha decidodo esperar con un total de " + total); //espera y le muestra el total personal a cada jugador
            hold = true;
            return hold;
        }

        
    }
}
