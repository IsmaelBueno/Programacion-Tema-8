using System;
using System.IO;

namespace Ejercicio_12
{
    class Program
    {
        static void Main(string[] args)
        {        
            Console.Title = "Ejercicio 12";

            string ruta = @"c:/Users/Ismael/Desktop/a/prueba1.txt";
            int numerolineas = 0;
            string contenido = string.Empty;
            int numeropalabras;

            if (!File.Exists(ruta))
            {
                Console.Clear();
                Console.WriteLine("Imposible encontrar el archivo");
                return;
            }

            FileInfo fichero = new FileInfo(ruta);

            //Numero de lineas
            using (StreamReader lector = new StreamReader(ruta))
            {
                while (lector.ReadLine() != null)
                {
                    numerolineas++;
                }
            }

            using (StreamReader lector = new StreamReader(ruta))
            {
                contenido = lector.ReadToEnd();
            }
            Console.WriteLine("Número de lineas en el fichero: {0} líneas",numerolineas);

            //Tamaño
            Console.WriteLine("Tamaño del fichero: {0} bytes",fichero.Length);

            //Atributos
            Console.WriteLine("Atributo del fichero: {0}", fichero.Attributes);

            //Numero de palabras
            char[] separadores = {' ', ':', '\n', '_', '\r', '\t'};
            string[] palabras = contenido.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
            numeropalabras = palabras.Length;
            Console.WriteLine("Número de palabras: {0} palabras",numeropalabras);

            Console.ReadKey();
        }
    }
}