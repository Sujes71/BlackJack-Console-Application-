using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Baraja
    {
        Carta[] cartas;
        Queue<Carta> cola;
        Jugador j1;
        Jugador j2;
        public static int turno;
        public Baraja()
        {
            cartas = new Carta[52];
            cola = new Queue<Carta>();
            j1 = new Jugador("Jugador 1");
            j2 = new Jugador("IA");
            iniciar();

        }
        public Carta[] GetCartas()
        {
            return cartas;
        }
        public Queue<Carta> getCola()
        {
            return cola;
        }
        public Jugador getj1()
        {
            return j1;
        }
        public Jugador getj2()
        {
            return j2;
        }
        public void iniciar()
        {
            for (int i = 0; i < 52; i++)
            {
                cartas[i] = new Carta();
            }
        }
        public void barajar()
        {
            Random rnd = new Random();
            int num;

            while (cola.Count != 52)
            {
                num = rnd.Next(0, 52);
                if (!cola.Contains(cartas[num]))
                {
                    cola.Enqueue(cartas[num]);
                }
            }
        }
        public void pedirCarta()
        {
            if (turno % 2 == 0)
            {
                j1.setLista(cola.Dequeue());
                turno++;
            }
            else
            {
                j2.setLista(cola.Dequeue());
                turno++;
            }
        }
        public bool winCondition()
        {
            if (j1.seHaPasado() || j1.getValor() < j2.getValor())
            {
                return false; ;
            }
            return true;
        }
        public void jugada()
        {
            turno = 0;
            string respuesta = "si";
            bool aux = true;
            bool aux2 = true;
            do
            {
                if (respuesta.Equals("si"))
                {
                    pedirCarta();
                    j1.mostrarCartas();
                    Console.WriteLine("¿Quieres carta?");
                    respuesta = Console.ReadLine().ToLower();
                }
                else if (respuesta.Equals("no"))
                {
                    j1.mostrarCartas();
                    aux = false;
                    turno++;
                }
                else
                {
                    Console.WriteLine("Responda <si> o <no>");
                    turno++;
                    Console.WriteLine("¿Quieres carta?");
                    respuesta = Console.ReadLine().ToLower();
                }

                if (cola.Peek().getValor() + j2.getValor() <= 21)
                {
                    pedirCarta();
                }
                else
                {
                    aux2 = false;
                    turno++;
                }

            }while (aux == true || aux2 == true);

            Console.Clear();
            Console.WriteLine("FIN DEL JUEGO :");
            j1.mostrarCartas();
            j2.mostrarCartas();
            if (winCondition() && !(j1.getValor() == j2.getValor()))
            {
                Console.WriteLine();
                Console.WriteLine("HAS GANADO "+j1.getNombre());
            }
            else if(j1.getValor() == j2.getValor())
            {
                Console.WriteLine("EMPATE");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("HAS PERDIDO LOOSER");
            }
        }
    }
}
