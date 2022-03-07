using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BlackJack
{
    class Jugador
    {
        private int valor;
        private string nombre;
        private List<Carta> lista;

        public Jugador(string nombre)
        {
            lista = new List<Carta>();
            this.nombre = nombre;
        }
        public int getValor()
        {
            return valor;
        }
        public string getNombre()
        {
            return nombre;
        }
        public List<Carta> getLista()
        {
            return lista;
        }
        public void setLista(Carta carta)
        {
            lista.Add(carta);
            valor += carta.getValor();
        }
        public bool seHaPasado()
        {
            if(valor > 21)
            {
                return true;
            }
            return false;
        }
        public void mostrarCartas()
        {
            Console.WriteLine("Cartas => " + nombre);
            Console.Write("{ ");
            foreach (var item in lista)
            {
                Console.Write(" "+item+" ");
            }
            Console.WriteLine(" }");
        }
        public void reset()
        {
            valor = 0;
            lista.Clear();
        }
    }
}
