﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Blackjack_21.Cartas;

namespace Blackjack_21
{
    

    public class Cartas
    {

        public Posicion numero { get; set; }
       
        public tipoDeCarta variedad { get; set; }

        public int valor { get; set; }

        public enum tipoDeCarta
        {
            Espada = 1,
            Copas = 2,
            Oros = 3,
            Bastos = 4
        }

        public enum Posicion
        {
            As = 1,
            Dos = 2,
            Tres = 3,
            Cuatro = 4,
            Cinco = 5,
            Seis = 6,
            Siete = 7,
            Ocho = 8,
            Nueve = 9,
            Diez = 10,
            Jack = 11,
            Reina = 12,
            Rey = 13

        }

    }

    public class Baraja
    {
        public int rango = 51;

        public List<Cartas> baraja = new List<Cartas>();
        public Baraja()
        {
            llenarBarraja(); //Llena la baraja con cartas
        }

        public void mezclarCartas()
        {
            baraja =  baraja.OrderBy(c => Guid.NewGuid()).ToList(); // Ordena aleatoriamente las cartas de la baraja
        }
        private  void llenarBarraja()
        {
            int valorM = 1;
            int repetido = 0;
            baraja = Enumerable.Range(1, 4).SelectMany(s => Enumerable.Range(1, 13).Select(c => new Cartas() //Utilizando los enumerables se llena la baraja con cada naipe y 13 cartas de cada naipe
            {
                numero = (Posicion)c,
                variedad = (tipoDeCarta)s,
                
                
            }
           )
          ) .ToList();
            foreach (var Carta in baraja) // se utiliza para darle valor a las cartas
            {
                if (repetido == 4) { // se utiliza para reninicar el contador de valores
                    valorM = 1;
                    repetido = 0;
                }
                Carta.valor = valorM;
                if(valorM <= 9) // se le agrega 1 hasta llegar al 10, una vez ahi solo se mantiene el 10 hasta que pase el rey
                {
                    valorM += 1;
                }
                else
                {
                    repetido += 1; //cuenta cuantas veces se ha repetido el 10, si llega a 4 se reinicia el contador
                }
                
            }
        }
        public Cartas tomarCarta()
        {
           
            var carta = baraja.FirstOrDefault(); //Saca la primera carta de la baraja y la elimina de la lista
            baraja.Remove(carta);
            

            return carta;
        }
        public void mostrarCartas() { // Se utilizo para mostrar las cartas sacadas, no se utiliza por el momento.
            
            foreach (var Carta in baraja)
            {
                string variedad = Carta.variedad.ToString();
                int numeroCarta = (int)Carta.numero;
                Console.WriteLine (variedad+ " " + numeroCarta +" "+ Carta.valor);
            }
        
        }
    }

   
}
