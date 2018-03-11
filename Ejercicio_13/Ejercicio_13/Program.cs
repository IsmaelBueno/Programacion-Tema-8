using System;
using System.IO;

namespace Ejercicio_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 13";

            Console.WriteLine("Has ejecutado el programa");
            Registro();
            Console.WriteLine("Ha terminado el programa...");
            Console.ReadKey();
        }

        static void Registro()
        {
            string ruta = @"./registro.txt";
            using (FileStream flujo = new FileStream(ruta, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter escritor = new StreamWriter(flujo))
                {
                    escritor.WriteLine("Usuario: " + Environment.UserName);
                    escritor.WriteLine("Fecha: " + DateTime.Now);
                    escritor.WriteLine("-".PadRight(40,'-'));
                }
            }
        }
    }
}
