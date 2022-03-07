using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BlackJack
{
    class Carta
    {
        private string palo;
        private string numero;
        private int valor;

        public static int contador = 0;
        public Carta()
        {
            añadirCarta();
        }
        public string getPalo()
        {
            return palo;
        }
        public int getValor()
        {
            return valor;
        }
        public string getNumero()
        {
            return numero;
        }
        public void setPalo(string palo)
        {
            this.palo = palo;
        }
        public void setNumero(string numero)
        {
            this.numero = numero;
        }
        
        public readonly string[] palos ={ "Picas", "Rombos", "Corazones", "Treboles" };
        public readonly string[] numeros = {"A","2","3","4","5","6","7","8","9","10","J","Q","K"};

        public void añadirCarta()
        {
            if (contador < 13)
            {
                palo = palos[0];
                numero = numeros[contador];
            }
            else if (contador >= 13 && contador < 26)
            {
                palo = palos[1];
                numero = numeros[contador - 13];
            }
            else if (contador >= 26 && contador < 39)
            {
                palo = palos[2];
                numero = numeros[contador - 26];
            }
            else if (contador >= 39 && contador < 52)
            {
                palo = palos[3];
                numero = numeros[contador - 39];
            }
            if(contador == 0 || contador == 13 || contador == 26 || contador == 39)
            {
                valor = 1;
            }
            else if (contador < 10 && contador > 0) valor = contador + 1;
            else if (contador < 23 && contador > 13) valor = contador - 12;
            else if (contador < 36 && contador > 26) valor = contador - 25;
            else if (contador < 49 && contador > 39) valor = contador - 38;
            else if (contador == 10 || contador == 11 || contador == 12 || contador == 23 || contador == 24 || contador == 25 || contador == 36 ||contador == 37 || contador == 38 || contador == 49 || contador == 50 || contador == 51 ) valor = 10;

            contador++;
        }
        public override string ToString()
        {
            return string.Format("{0} de {1}",numero,palo);
        }
    }
}
