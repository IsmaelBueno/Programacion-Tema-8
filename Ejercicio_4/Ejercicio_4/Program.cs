using System;
using System.IO;

namespace Ejercicio_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 4";
            string[] datos = new string[4];

            //obtención de datos
            Console.WriteLine("Este programa crea una copia de un archivo existente, pero ignorando un caracter");
            Console.WriteLine();
            Console.Write("Archivo: ");
            datos[0] = Console.ReadLine();
            Console.Write("Ruta de origen (si es esta puedes dejarla en blanco): ");
            datos[1] = Console.ReadLine();
            Console.Write("Ruta de destino (si es esta puedes dejarla en blanco): ");
            datos[2] = Console.ReadLine();
            Console.Write("Caracter para ignorar: ");
            datos[3] = Console.ReadLine();

            //Compruebación de datos
            if (!Directory.Exists(datos[1]))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No se pudo encontrar la ruta de origen");
                Console.ReadKey();
                return;
            }

            if (!Directory.Exists(datos[2]))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No se pudo encontrar la ruta de de destino");
                Console.ReadKey();
                return;
            }

            if (!File.Exists(datos[1]+"/"+datos[0]))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No se pudo encontrar el archivo");
                Console.ReadKey();
                return;
            }

            if (datos[3].Length != 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Problema al reconocer el carácter, debes introducir un solo carácter");
                Console.ReadKey();
                return;
            }

            //Reliza la copia
            try
            {
                //Lectura del fichero de origen
                string rutaorigen = datos[1] + "/" + datos[0];
                StreamReader lectororigen = new StreamReader(rutaorigen);

                string contenido = lectororigen.ReadToEnd();

                lectororigen.Close();

                //Modificar contenido sin el caracter
                string contenidosincaracter = string.Empty;
                for (int i = 0; i < contenido.Length; i++)
                {
                    if (contenido[i] != char.Parse(datos[3]))
                    {
                        contenidosincaracter += contenido[i];
                    }
                }

                //Escritura en el fichero de origen

                string rutadestino = datos[2] + "/" + Path.GetFileNameWithoutExtension(datos[0]) + "Copia" + Path.GetExtension(datos[0]);

                //Creacion del archivo si no existe, si no lo va a sobreescribir
                FileStream creacionarchivo = new FileStream(rutadestino, FileMode.Create, FileAccess.Write);

                StreamWriter escritor = new StreamWriter(creacionarchivo);
                escritor.Write(contenidosincaracter);

                escritor.Close();
                creacionarchivo.Close();
           
            }
            catch (Exception)
            {
                Console.WriteLine("Error al realizar la copia");
                Console.ReadKey();
                return;
            }
        }
    }
}
