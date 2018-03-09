using System;
using System.IO;

namespace Ejercicio_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 11";

            bool salir = false;
            string ruta;
            string contenido = string.Empty;

            //Creación y compruebación del archivo y la ruta 
            Console.WriteLine("Introduce la ruta donde quieres que se guarde el fichero");
            ruta = Console.ReadLine();

            try
            {
                if (!Directory.Exists(ruta))
                {
                    Console.Clear();
                    Console.WriteLine("Imposible encontrar la ruta");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Ahora introduce el contenido en el fichero, cuando quieras acabar introduce una linea vacía");

                //Escritura del documento
                using (FileStream flujo = new FileStream(ruta + "/DocumentoEjercicio11.txt", FileMode.CreateNew, FileAccess.Write))
                {                  
                    using (StreamWriter escritura = new StreamWriter(flujo))
                    {
                        while (!salir)
                        {
                            string Anadir = Console.ReadLine();
                            if (Anadir == "") salir = true;
                            else escritura.Write(Anadir + Environment.NewLine);
                        }
                    }
                }

                //Lectura del documento
                using (FileStream flujo2 = new FileStream(ruta + "/DocumentoEjercicio11.txt",FileMode.Open,FileAccess.Read))
                {
                    using (StreamReader lectura = new StreamReader(flujo2))
                    {
                    contenido = lectura.ReadToEnd();
                    }
                }
                

                Console.Clear();
                Console.WriteLine(contenido);
                Console.WriteLine("\n\n\nAsí ha quedado el documento, pulsa cualquier tecla para salir...");
                Console.ReadKey();

            }
            catch (Exception)
            {
                Console.WriteLine("Error al intentar escribir/leer el archivo");
                Console.ReadKey();
            }

        }
    }
}
