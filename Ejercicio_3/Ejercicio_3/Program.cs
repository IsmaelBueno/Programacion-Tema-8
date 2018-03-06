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

            string ficheroorigen = "";
            string ficherodestino = "";

            Console.WriteLine("Este programa copia el contenido especificado de un fichero en otro");
            try
            {

                Console.WriteLine("A continuación introduce la ruta de origen (absoluta o de origen), si es el directorio actual no introduzcas nada");
                ficheroorigen = Console.ReadLine();
                if (ficheroorigen == "")
                {
                    ficheroorigen = @"./";
                }

                Console.WriteLine("Ahora introduce la ruta en la que quieres copiar el archivo, si es el directorio actual no introduzcas nada");
                ficherodestino += Console.ReadLine();
                if (ficherodestino == "")
                {
                    ficherodestino = @"./";
                }


                //comprueba si existen los datos introducidos
                if (!Directory.Exists(ficheroorigen))
                {
                    Console.WriteLine("No se pudo encontrar el directiorio de origen");
                    Console.ReadKey();
                    return;
                }
                if (!Directory.Exists(ficherodestino))
                {
                    Console.WriteLine("No se pudo encontrar el directorio de destino");
                    Console.ReadKey();
                    return;
                }

                string[] archivos = null;
                string[] directorios = null;

                archivos = Directory.GetFiles(ficheroorigen);
                directorios = Directory.GetDirectories(ficheroorigen);

                
                //realiza la copia
                for (int i = 0; i < archivos.Length; i++)
                {
                    File.Copy(archivos[i], ficherodestino + "/" + Path.GetFileName(archivos[i]));
                }

                for (int i = 0; i < directorios.Length; i++)
			    {
                    DirectoryInfo tmp = new DirectoryInfo(directorios[i]);
                    Directory.CreateDirectory(ficherodestino+"/"+tmp.Name);
                }

                Console.Clear();
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