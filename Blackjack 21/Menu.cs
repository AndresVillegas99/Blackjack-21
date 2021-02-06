using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_21
{
    class Menu
    {
        Calculaciones calc = new Calculaciones();
        public static void menus()
        {
            Console.WriteLine("Escoja su modo a jugar. 1)Contra maquina 2=) contra personas"); // menu para escoger el modo deseado
            int modo = 0;
            modo = int.Parse(Console.ReadLine());
            Menu MenuP = new Menu();
            switch (modo)
            {
                case 1:
                    MenuP.VSmaquina();
                    break;
                case 2:
                    MenuP.VSjugador();
                    break;
                default:
                    break;
            }
        }
        public  void VSmaquina()
        {                       //Se crean todas las variables que utilizara el jugador y la maquina, respectivamente
            int total1 = 0;
            int total2 = 0;
            bool esperando = false;
            bool esperandoC = false;
            Baraja A = new Baraja();
            Jugador B = new Jugador();
            House casa = new House();
            Menu MenuP = new Menu();

            // indica instrucciones al jugador
            Console.WriteLine("Bienvenido a Blackjack 21, seria jugador vs la casa.");
            Console.WriteLine("Tiene 4 opciones, 1)revisar cartas PROPIAS, 2)pedir 1 carta, 3)Salir 4)esperar");
            Console.WriteLine("Escriba el numero de la accion que desea realizar.");
            A.mezclarCartas();

            casa.unaMasCasa(A); //Le da 2 cartas a la casa y al jugador
            casa.unaMasCasa(A);
            B.unaMas(A);
            B.unaMas(A);
            MenuP.menuVSMaquina(total1, total2, esperando, esperandoC, A, B, casa); //muestra el menu de VSMaquina
        }

        public  void VSjugador()
        {
            Baraja A = new Baraja();
            int jugadores = 0;
            int ganador = 0;
            List<Jugador> jugadoresEnPartida = new List<Jugador>();
            List<int> puntosJugadores = new List<int>();
            List<bool> esperandoJugadores = new List<bool>();
            Menu MenuP = new Menu();

            Console.WriteLine("Cuantas personas van a jugar, maximo 4");
            MenuP.menuVSJugador(jugadores, ganador, jugadoresEnPartida, puntosJugadores, esperandoJugadores, A);


        }

        public  void menuVSJugador(int jugadores, int ganador, List<Jugador> jugadoresEnPartida, List<int> puntosJugadores, List<bool> esperandoJugadores, Baraja A)
        {

            jugadores = calc.decidirJugadores(jugadores);
           
            for (int i = 0; i < jugadores; i++)
            {
                Jugador X = new Jugador(); //Se crea los jugadores y sus porpiedades nhecesarias y se agregan en listas.
                int Y = new int();
                bool pass = false;
                jugadoresEnPartida.Add(X);
                puntosJugadores.Add(Y);
                esperandoJugadores.Add(pass);
            }
            A.mezclarCartas();
            foreach (Jugador jug in jugadoresEnPartida) //Se les dan 2 cartas a cada jugador
            {
                jug.unaMas(A);
                jug.unaMas(A);
            }
            Console.WriteLine("Bienvenido a Blackjack 21, seria jugador vs jugador.");
            Console.WriteLine("Tiene 4 opciones, 1)revisar cartas PROPIAS, 2)pedir 1 carta, 3)Salir 4)esperar");
            Console.WriteLine("Escriba el numero de la accion que desea realizar.");

            for (int i = 0; i < jugadores; i++)  //Este menu es igual al de vs maquina, pero una vez que el jugador decida esperar le da el turno al siguiente jugador.
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
                            if (jugadores >= (i + 2))
                            {
                                Console.WriteLine("Ahora es el turno del jugador " + (i + 2)); //Indica de quien es el siguiente turno
                            }
                            break;
                        default:
                            Console.WriteLine("Escoja una opcion valida");
                            break;
                    }
                } while (!esperandoJugadores[i]);

                if (!esperandoJugadores.Contains(false))
                {
                    calc.resultadosJugadores(jugadores, puntosJugadores, ganador);
                }
            }
        }

        public  void menuVSMaquina(int total1, int total2, bool esperando, bool esperandoC, Baraja A, Jugador B, House casa)
        {
            Menu MenuP = new Menu();
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
                calc.ganadorRevisa(esperandoC, total2, total1); //Una vez que la maquina llegue a su limite de 15 y espere se revisara quien gano
                esperandoC = calc.casaSaca(esperando, esperandoC, total2, casa, A); //Si la maquina no ha llegado a su limite de 15 utiliza este metoedo para sacar cartas
                Console.WriteLine("La casa jugo, es su turno");


                calc.comparar(total1, total2);
            }
        }

        

        

    }
}
