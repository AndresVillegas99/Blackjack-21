using System;
using System.Collections.Generic;

namespace Blackjack_21
{
    class Program
    {
        static void Main(string[] args)
        {
            int modo = 0;
            switch (modo)
            {
                case 1:
                    VSmaquina();
                    break;
                case 2:
               //     VSjugador();
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
            while (true)
            {
                do // este loop es para el jugador que decida sus movimientos y solo sale una vez que decide esperar
                {
                    int accion = int.Parse(Console.ReadLine());
                    switch (accion)
                    {
                        case 1:
                            Console.WriteLine("Sus cartas son: ");
                            total1 = B.revisarCartas(total1);
                            total2 = casa.revisarCartasCasa(total2);
                            if (total1 >= 21 || total2 >= 21)
                            {
                                esperando = true;
                            }
                            break;
                        case 2:
                            B.unaMas(A);
                            break;
                        case 3:
                            B.salir();
                            break;
                        case 4:
                            esperando = B.espera(esperando, total1);
                            break;
                        default:
                            Console.WriteLine("Escoja una opcion valida");
                            break;
                    }
                } while (!esperando);



                if (esperandoC == true && total2 > 15) //se encarga de dar una respuesta si no hay nadie que supere 21
                {
                    if (total1 > total2)
                    {
                        Console.WriteLine("Su total es " + total1 + " , la casa tuvo " + total2);
                        Console.WriteLine("jugador gana");
                    }
                    else if (total1 < total2)
                    {
                        Console.WriteLine("Su total es " + total1 + " , la casa tuvo " + total2);
                        Console.WriteLine("casa gana");
                    }
                    else
                    {
                        Console.WriteLine("Su total es " + total1 + " , la casa tuvo " + total2);
                        Console.WriteLine("Empate, nadie gana");
                    }
                    Environment.Exit(0);

                }
                do
                {
                    if (esperando = true && total2 <= 18 && esperandoC == false)
                    {
                        casa.unaMasCasa(A);
                        total2 = casa.revisarCartasCasa(total2);
                    }
                    else
                    {
                        esperandoC = true;

                    }
                } while (!esperandoC);
                comparar(total1, total2);
            }
        }

        public static void VSjugador() 
        {
            Baraja A = new Baraja();
            int jugadores = 0;
            List<Jugador> jugadoresEnPartida =new List<Jugador> ();
            List<int> puntosJugadores = new List<int>();
            Console.WriteLine("Cuantas personas van a jugar, maximo 4");
            jugadores = int.Parse( Console.ReadLine());
            for (int i = 0; i < jugadores; i++) 
            {
                Jugador X = new Jugador();
                jugadoresEnPartida.Add(X);

            }
            for (int i = 0; i < jugadores; i++)
            {
               int Y = new int();
                puntosJugadores.Add(Y);

            }
            Console.WriteLine("Bienvenido a Blackjack 21, seria jugador vs la casa.");
            Console.WriteLine("Tiene 4 opciones, 1)revisar cartas PROPIAS, 2)pedir 1 carta, 3)Salir 4)esperar");
            Console.WriteLine("Escriba el numero de la accion que desea realizar.");
            A.mezclarCartas();
            for (int i = 0; i < jugadores; i++)
            {
                
            }
        }
    }


}
