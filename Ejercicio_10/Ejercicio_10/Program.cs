using System;
using System.IO;

namespace Ejercicio_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 10";

            string ruta = @"C:/Users/Ismael/Desktop/a/prueba1.txt";
            string contenido = string.Empty;

            if (!File.Exists(ruta))
            {
                Console.WriteLine("Imposible encontrar el archivo");
                Console.ReadKey();
                return;
            }

            using (StreamReader lectura = new StreamReader(ruta))
            {
                contenido = lectura.ReadToEnd();
            }

            for (int i = contenido.Length-1; i >= 0; i--)
            {
                Console.Write(contenido[i]);
            }

            Console.ReadKey();
        }
    }
}
