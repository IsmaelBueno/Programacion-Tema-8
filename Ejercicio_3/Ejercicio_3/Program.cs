using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 3";

            string[] datos = new string[3];
            string nombrefichero = string.Empty;
            string ficheroorigen = string.Empty;
            string ficherodestino = string.Empty;

            //Introducir datos
            Console.WriteLine("PROGRAMA PARA COPIAR UN ARCHIVO");
            Console.WriteLine("\nIntroduce el nombre del archivo, la ruta del archivo a copiar y la ruta donde lo quieres copiar, en caso de que una ruta sea en la que te encuentras puedes dejarla en blanco");
            Console.WriteLine();
            Console.Write("Archivo:"); 
            nombrefichero = Console.ReadLine();
            Console.Write("Ruta origen:"); 
            ficheroorigen = Console.ReadLine();
            Console.Write("Ruta destino:");
            ficherodestino = Console.ReadLine();

            if (ficheroorigen == "") ficheroorigen = "./";
            if (ficherodestino == "") ficherodestino = "./";
            //Comprobación de los datos
            if(!Directory.Exists(ficheroorigen))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No se pudo encontrar la ruta de origen");
                Console.ReadKey();
                return;
            }

            if(!File.Exists(ficheroorigen+"/"+nombrefichero))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No se pudo encontrar el archivo para copiar");
                Console.ReadKey();
                return;
            }

            if (!Directory.Exists(ficherodestino))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No se pudo encontrar el fichero de destino");
                Console.ReadKey();
                return;
            }

            //Copia del archivo
            try
            {
                File.Copy(ficheroorigen + "/" + nombrefichero, ficherodestino + "/" + Path.GetFileNameWithoutExtension(nombrefichero) + "Copia" + Path.GetExtension(nombrefichero));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Copia realizada con éxito");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Error al realizar la copia");
                Console.ReadKey();
            }
        }
    }
}