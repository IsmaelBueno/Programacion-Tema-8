using System;
using System.IO;

namespace Ejercicio_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio7";

            string rutaA = @"C:/basura/salida.txt";
            string rutaB = @"C:/basura2/salidaCopia.txt";

            if(ConcatenarArchivos(rutaA, rutaB)) Console.WriteLine("Concatenación correcta");
            else Console.WriteLine("Ha surgido un problema al intentar realizar la concatenación");
            Console.ReadKey();

        }

        static bool ConcatenarArchivos(string rutaA, string rutaB)
        {

            if (!File.Exists(rutaA)) throw new Exception("Imposible encontrar la ruta de A");
            if (!File.Exists(rutaB)) throw new Exception("Imposible encontrar la ruta de B");

            try
            {
                string contenidoB = string.Empty;

                using (StreamReader lecturaB = new StreamReader(rutaB))
                {
                    contenidoB = lecturaB.ReadToEnd();
                }

                using (FileStream flujoA = new FileStream(rutaA, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter escrituraA = new StreamWriter(flujoA))
                    {
                        escrituraA.Write(contenidoB);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
