using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Baraja b = new Baraja();
            Console.WriteLine("Bienvenido al juego BLACK JACK!");
            string respuesta = "si";
            while (!respuesta.Equals("no")) 
            {
                switch (respuesta)
                {
                    case "si":
                        Console.WriteLine("¿Desea comenzar una nueva partida?");
                        respuesta = Console.ReadLine().ToLower();
                        Console.Clear();
                        if (respuesta == "si")
                        {
                            b.getj1().reset();
                            b.getj2().reset();
                            b.getCola().Clear();
                            b.barajar();
                            b.jugada();  
                        }
                        break;
                    case "no":
                        Console.WriteLine("Gracias por jugar a mi juego");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Responda <si> o <no>");
                        respuesta = "si";
                        break;
                }
            }
        }
    }
}
