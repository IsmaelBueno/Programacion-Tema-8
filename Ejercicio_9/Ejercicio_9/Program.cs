using System;
using System.IO;

namespace Ejercicio_9
{
    class Program
    {

        static void Main(string[] args)
        {
           
            Console.Title = "Ejercicio 9";
            string ruta1 = @"c:/basura/salida.txt";
            string ruta2 = @"c:/basura/texto.txt";
            string ruta3 = @"c:/basura/salida2.txt";

            args = new string[] { ruta1, ruta2, ruta3 };

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(Path.GetFileNameWithoutExtension(args[i]));
                Console.WriteLine();
                using (StreamReader archivotmp = new StreamReader(args[i]))
                {
                    Console.WriteLine(archivotmp.ReadToEnd());
                }
                Console.WriteLine("-".PadRight(Console.WindowWidth,'-'));
            }

            Console.ReadKey();

        }

    }
}
