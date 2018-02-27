using System;
using System.IO;

namespace Ejercicio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 1";
            string ruta = @"c:/basura/basura1/basura2/basura3/texto.txt";

            Console.WriteLine("Información sobre el archivo:" + Path.GetFullPath(ruta));
            Console.WriteLine(".".PadRight(Console.WindowWidth,'.'));
            Console.WriteLine("\t             Ruta del directorio:   " + Path.GetDirectoryName(ruta));
            Console.WriteLine("\t                 Directorio raíz:   " + Path.GetPathRoot(ruta));
            Console.WriteLine("\t    ¿El archivo tiene extensión?:   " + Path.HasExtension(ruta));
            Console.WriteLine("\t              Nombre del archivo:   " + Path.GetFileName(ruta));
            Console.WriteLine("\tNombre del archivo sin extensión:   " + Path.GetFileNameWithoutExtension(ruta));
            Console.WriteLine("\t           Extensión del archivo:   " + Path.GetExtension(ruta));

            Console.ReadKey();
        }
    }
}
