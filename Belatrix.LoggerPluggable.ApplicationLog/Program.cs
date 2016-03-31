using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Belatrix.LoggerPluggable.ApplicationLog
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new LoggerBelatrix();

            Console.WriteLine("NET Test - BELATRIX \n");
            Console.WriteLine("Ingrese una opcion:");
            Console.WriteLine("1) Success");
            Console.WriteLine("2) Warning");
            Console.WriteLine("3) Error");
            Console.WriteLine("4) Salir \n");

            while (true)
            {

                var action = Console.ReadLine();
                Console.WriteLine("Escriba una mensaje a registrar:");
                var message = Console.ReadLine();
                if (!action.Equals("4"))
                {
                    switch (action)
                    {
                        case "1":
                            log.Message(message, Types.EventType.Success);
                            break;
                        case "2":
                            log.Message(message, Types.EventType.Warning);
                            break;
                        case "3":
                            log.Message(message, Types.EventType.Error);
                            break;
                    }
                }
                else
                    return;
            }
        }
    }
}
