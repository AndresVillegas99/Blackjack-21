using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_21
{
    class Calculaciones
    {
        public void ganadorRevisa(bool esperandoC, int total2, int total1)
        {
            if (esperandoC == true && total2 > 15) //se encarga de dar una respuesta si no hay nadie que supere 21
            {
                if (total1 > total2 && total1 < 22) //Si el jugador gana
                {
                    Console.WriteLine("Su total es " + total1 + " , la casa tuvo " + total2);
                    Console.WriteLine("jugador gana");
                }
                else if (total2 > 21)
                {
                    Console.WriteLine("Su total es " + total1 + " , la casa tuvo " + total2);
                    Console.WriteLine("jugador gana");
                }

                else if (total1 < total2 && total2 < 22)// Si la maquina gana
                {
                    Console.WriteLine("Su total es " + total1 + " , la casa tuvo " + total2);
                    Console.WriteLine("casa gana");
                }
                else if (total1 > 21)
                {
                    Console.WriteLine("Su total es " + total1 + " , la casa tuvo " + total2);
                    Console.WriteLine("casa gana");
                }
                else //Si hay un empate entre jugador y maquina
                {
                    Console.WriteLine("Su total es " + total1 + " , la casa tuvo " + total2);
                    Console.WriteLine("Empate, nadie gana");
                }
                Environment.Exit(0);

            }
        }
        public bool casaSaca(bool esperando, bool esperandoC, int total2, House casa, Baraja A)
        {
            do
            {
                if (esperando = true && total2 <= 18 && esperandoC == false) //revisa si el jugador ya paso su turno
                {
                    casa.unaMasCasa(A); //metodo de la casa para sacar cartas
                    total2 = casa.revisarCartasCasa(total2); //actualiza el valor de total2, el cual es el de la casa
                }
                else
                {
                    esperandoC = true; //cambia el valor de esperando de la casa, asi diciendo que el jugador puede jugar.

                }
            } while (!esperandoC);
            return esperandoC;
        }

        public int decidirJugadores(int jugadores)
        {
            do
            {
                jugadores = int.Parse(Console.ReadLine()); //Restricion para solo se pueda tener 4 jugadores maximo, y no menos de 2 
                if (jugadores > 4)
                {
                    Console.WriteLine("Solo maximo 4 jugadores");

                }
                else if (jugadores == 1)
                {
                    Console.WriteLine("Unico jugador unico ganador");
                    Environment.Exit(0);
                }
                else if (jugadores < 1)
                {
                    Console.WriteLine("No se puede jugar sin jugadores");
                    Environment.Exit(0);
                }

            } while (jugadores > 4);
            return jugadores;
        }

        public void resultadosJugadores(int jugadores, List<int> puntosJugadores, int ganador)
        {
            Console.WriteLine("Todos los jugadores estan listos. Los puntos de los jugadores son: ");
            for (int t = 0; t < jugadores; t++)
            {
                Console.WriteLine(puntosJugadores[t]);
            }
            List<int> puntosJugadoresOrden = new List<int>(puntosJugadores); //Crea una nueva lista para tener el orden de mayor a menor en puntos
            puntosJugadoresOrden.Sort();
            puntosJugadoresOrden.Reverse();
            for (int z = 0; z < jugadores; z++) // utiliza la lista ordenana y la desordenada  y busa cual jugador tuvo el puntaje mas alto, y lo guarda en 'ganador'
            {
                int p1 = puntosJugadoresOrden[z];
                for (int zz = 0; zz < jugadores; zz++)
                {
                    int p2 = puntosJugadores[zz];
                    if (p1 == p2)
                    {
                        ganador = zz + 1;
                    }
                }
                break;
            }
            for (int p = 0; p < jugadores - 1; p++)
            {
                if (puntosJugadoresOrden[p] > puntosJugadoresOrden[p + 1]) //Indica quien fue el ganador
                {
                    Console.WriteLine("El jugador " + (ganador) + " ha ganado con " + puntosJugadoresOrden[p] + " puntos");
                    break;
                }
                else if (puntosJugadoresOrden[p] == puntosJugadoresOrden[p + 1]) //Indica si hubo un empate
                {
                    Console.WriteLine("Ha ocurrido un empate, uno o mas jugadores tienen los mismos puntos, nadie gana");
                    break;
                }
                else //Indica si el ganador no esta de primero en la lista.
                {
                    Console.WriteLine("El jugador " + (p + 2) + " ha ganado con " + puntosJugadoresOrden[p + 1] + " puntos");
                    break;
                }
            }
        }
        public void comparar(int a, int b) //se utiliza para comparar en caso de que el primer metodo de comparacion no funcione.
        {

            if (a == 21 && b == 21)
            {
                Console.WriteLine("Su total es " + a + " , la casa tuvo " + b);
                Console.WriteLine("Empate, nadie gana ");
                Environment.Exit(0);
            }
            else if (b == 21)
            {
                Console.WriteLine("Su total es " + a + " , la casa tuvo " + b);
                Console.WriteLine("Casa gana");
                Environment.Exit(0);
            }
            else if (a == 21)
            {
                Console.WriteLine("Su total es " + a + " , la casa tuvo " + b);
                Console.WriteLine("Jugador gana");
                Environment.Exit(0);
            }
            else if (a > 21)
            {
                Console.WriteLine("Su total es " + a);
                Console.WriteLine("Jugador perdio");
                Environment.Exit(0);
            }
            else if (b > 21)
            {
                Console.WriteLine("Su total es " + a + " , la casa tuvo " + b);
                Console.WriteLine("Casa perdio");
                Environment.Exit(0);
            }


        }
    }
}
