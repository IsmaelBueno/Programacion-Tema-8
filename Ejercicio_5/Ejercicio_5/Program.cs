using System;
using System.IO;

namespace Ejercicio_5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Title = "Ejercicio 5";

            Console.WriteLine("Introduce la ruta del archivo para ver su contenido (C:/carpeta/archivo.txt)");
            string ruta = Console.ReadLine();

            if (!File.Exists(ruta))
            {
                Console.Clear();
                Console.WriteLine("Imposible encontrar el archivo...");
                Console.ReadKey();
                return;
            }
            using (StreamReader lector = new StreamReader(ruta))
            {
                Console.Clear();
                Console.WriteLine(lector.ReadToEnd());
            }
           
            Console.WriteLine("\n\n\nEste es todo el contenido...");
            Console.ReadKey();
        }
    }
}
