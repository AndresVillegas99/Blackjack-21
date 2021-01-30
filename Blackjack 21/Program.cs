using System;
using System.Collections.Generic;

namespace Blackjack_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escoja su modo a jugar. 1)Contra maquina 2=) contra personas");
            int modo = 0;
            modo = int.Parse(Console.ReadLine());
            switch (modo)
            {
                case 1:
                    VSmaquina();
                    break;
                case 2:
                  VSjugador();
                    break;
                default:
                    break;
            }
        }

        public static void comparar(int a, int b)
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
                Console.WriteLine("Su total es " + a );
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

        public static void VSmaquina() 
        {
            int total1 = 0;
            int total2 = 0;
            bool esperando = false;
            bool esperandoC = false;
            Baraja A = new Baraja();
            Jugador B = new Jugador();
            House casa = new House();

            
            Console.WriteLine("Bienvenido a Blackjack 21, seria jugador vs la casa.");
            Console.WriteLine("Tiene 4 opciones, 1)revisar cartas PROPIAS, 2)pedir 1 carta, 3)Salir 4)esperar");
            Console.WriteLine("Escriba el numero de la accion que desea realizar.");
            A.mezclarCartas();

            casa.unaMasCasa(A);
            casa.unaMasCasa(A);
            B.unaMas(A);
            B.unaMas(A);
            menuVSMaquina(total1, total2, esperando, esperandoC, A, B, casa);
        }

        public static void VSjugador() 
        {
            Baraja A = new Baraja();
            int jugadores = 0;
            int ganador = 0;
            List<Jugador> jugadoresEnPartida = new List<Jugador>();
            List<int> puntosJugadores = new List<int>();
            List<bool> esperandoJugadores = new List<bool>();

            Console.WriteLine("Cuantas personas van a jugar, maximo 4");
            
            do
            {
                jugadores = int.Parse(Console.ReadLine());
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
                
            } while (jugadores > 4) ;

                for (int i = 0; i < jugadores; i++)
            {
                Jugador X = new Jugador();
                int Y = new int();
                bool pass = false;
                jugadoresEnPartida.Add(X);
                puntosJugadores.Add(Y);
                esperandoJugadores.Add(pass);
            }
            A.mezclarCartas();
            foreach (Jugador jug in jugadoresEnPartida)
            {
                jug.unaMas(A);
                jug.unaMas(A);
            }
            Console.WriteLine("Bienvenido a Blackjack 21, seria jugador vs jugador.");
            Console.WriteLine("Tiene 4 opciones, 1)revisar cartas PROPIAS, 2)pedir 1 carta, 3)Salir 4)esperar");
            Console.WriteLine("Escriba el numero de la accion que desea realizar.");

            for (int i = 0; i < jugadores; i++)
            {
                do // este loop es para el jugador que decida sus movimientos y solo sale una vez que decide esperar
                {
                    int accion = int.Parse(Console.ReadLine());
                    switch (accion)
                    {
                        case 1:
                            Console.WriteLine("Sus cartas son: ");
                            puntosJugadores[i] = jugadoresEnPartida[i].revisarCartas(puntosJugadores[i]);

                            if (puntosJugadores[i] >= 21)
                            {
                                esperandoJugadores[i] = true;
                            }
                            break;
                        case 2:
                            jugadoresEnPartida[i].unaMas(A);
                            break;
                        case 3:
                            jugadores = jugadoresEnPartida[i].salir(jugadoresEnPartida, jugadores, jugadoresEnPartida[i]);
                            break;
                        case 4:
                            esperandoJugadores[i] = jugadoresEnPartida[i].espera(esperandoJugadores[i], puntosJugadores[i]);
                            if(jugadores>= (i + 2)) {
                                Console.WriteLine("Ahora es el turno del jugador " + (i + 2));
                            }
                            
                            break;
                        default:
                            Console.WriteLine("Escoja una opcion valida");
                            break;
                    }
                } while (!esperandoJugadores[i]);

                if (!esperandoJugadores.Contains(false))
                {
                    Console.WriteLine("Todos los jugadores estan listos. Los puntos de los jugadores son: ");
                    for (int t = 0; t < jugadores; t++)
                    {
                        Console.WriteLine(puntosJugadores[t]);
                    }
                    List<int> puntosJugadoresOrden = new List<int>(puntosJugadores);
                    puntosJugadoresOrden.Sort();
                    puntosJugadoresOrden.Reverse();
                    for(int z = 0; z< jugadores; z++)
                    {
                        int p1 = puntosJugadoresOrden[z];
                        for (int zz = 0; zz < jugadores; zz++) 
                        {
                            int p2 = puntosJugadores[zz];
                            if (p1 == p2) 
                            {
                                 ganador = zz+1;
                                
                            }
                            
                        }
                        break;
                    }
                    for (int p = 0; p < jugadores - 1; p++)
                    {
                        if (puntosJugadoresOrden[p] > puntosJugadoresOrden[p + 1])
                        {
                            Console.WriteLine("El jugador " + (ganador) + " ha ganado con " + puntosJugadoresOrden[p] + " puntos");
                            break;
                        }
                        else if (puntosJugadoresOrden[p] == puntosJugadoresOrden[p + 1])
                        {
                            Console.WriteLine("Ha ocurrido un empate, uno o mas jugadores tienen los mismos puntos, nadie gana");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("El jugador " + (p + 2) + " ha ganado con " + puntosJugadoresOrden[p+1] + " puntos");
                            break;
                        }
                    }
                }
            }
        }

        public static void menuVSMaquina(int total1, int total2, bool esperando, bool esperandoC, Baraja A, Jugador B, House casa)
        {
            while (true)
            {
                do // este loop es para el jugador que decida sus movimientos y solo sale una vez que decide esperar
                {
                    int accion = int.Parse(Console.ReadLine());
                    switch (accion)
                    {
                        case 1:
                            Console.WriteLine("Sus cartas son: "); //Muestra las cartas de el jugador
                            total1 = B.revisarCartas(total1);       //Consigue los totales del jugador y de la casa
                            total2 = casa.revisarCartasCasa(total2);
                            if (total1 >= 21 || total2 >= 21) // Si el jugador o la casa se pasa de 21 termian el proceso de un solo
                            {
                                esperando = true;
                            }
                            break;
                        case 2:
                            B.unaMas(A); //Saca una carta de la baraja
                            break;
                        case 3:
                            Console.WriteLine("Decidio salirse de la partida, la casa gana"); //Termina el jeugo
                            Environment.Exit(0);
                            break;
                        case 4:
                            esperando = B.espera(esperando, total1);  //Espera y le da el turno a la maquina
                            break;
                        default:
                            Console.WriteLine("Escoja una opcion valida");
                            break;
                    }
                } while (!esperando);
                total2 = casa.revisarCartasCasa(total2);
                ganadorRevisa(esperandoC, total2, total1); //Una vez que la maquina llegue a su limite de 15 y espere se revisara quien gano
                esperandoC = casaSaca(esperando, esperandoC, total2, casa, A); //Si la maquina no ha llegado a su limite de 15 utiliza este metoedo para sacar cartas

               
                
                comparar(total1, total2);
            }
        }
        public static void ganadorRevisa(bool esperandoC, int total2, int total1)
        {
            if (esperandoC == true && total2 > 15) //se encarga de dar una respuesta si no hay nadie que supere 21
            {
                if (total1 > total2 && total1 < 22) //Si el jugador gana
                {
                    Console.WriteLine("Su total es " + total1 + " , la casa tuvo " + total2);
                    Console.WriteLine("jugador gana");
                }
                else if (total2 > 21 )
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
        public static bool casaSaca(bool esperando, bool esperandoC, int total2, House casa, Baraja A)
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
    }


}
