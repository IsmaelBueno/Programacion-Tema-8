using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_8
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Title = "Ejercicio 8";

            string[] alumnos = new string[] {"Antonio, Pim Pam","Ismael, Bueno Molina","Adrian, Muñoz Mudarra","Tocayo, Salmeron Muñoz","Dani, Casado Molina","Jose Luis, Apellidos Imaginarios"};
            string ruta = @"c:/basura/alumno_datos.txt";

            CrearFichero(ruta, alumnos);
            ListarContenidoFichero(ruta);

            Console.ReadKey();
        }

        static bool CrearFichero(string ruta, string[] alumnos)
        {
            try
            {
                using (FileStream flujo = new FileStream(ruta, FileMode.CreateNew, FileAccess.Write))
                {
                    using (StreamWriter escritura = new StreamWriter(flujo))
                    {
                        for (int i = 0; i < alumnos.Length; i++)
                        {
                            escritura.WriteLine(alumnos[i] + ";");
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static bool ListarContenidoFichero(string ruta)
        {
            string contenido = string.Empty;
            try
            {
                //Lectura
                using (StreamReader lectura = new StreamReader(ruta))
                {
                    contenido = lectura.ReadToEnd();
                }

                //Mostrar contenido
                for (int i = 0; i < contenido.Length; i++)
                {
                    if (contenido[i] == ';')
                    {
                        Console.WriteLine();
                    }
                    else 
                    {
                        Console.Write(contenido[i]);
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
