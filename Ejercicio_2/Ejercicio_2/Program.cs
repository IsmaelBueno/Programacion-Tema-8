using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_2
{
    /*
     * Haz un programa, Windows, que muestre información sobre un directorio usando 
     * la clase: DirectoryInfo, el
        directorio se seleccionará usando un componente windows.
     */
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"C:/Windows/Boot";
            DirectoryInfo windowsboot = new DirectoryInfo(ruta);
            Console.WriteLine("\tInformación del directorio \"{0}\", en la ruta \"{1}\"",windowsboot.Name,windowsboot.FullName);
            Console.WriteLine("..................................................................................");
            Console.WriteLine("\tRuta completa del directorio:                      " + windowsboot.FullName);
            Console.WriteLine("\tNombre del directorio:                             " + windowsboot.Name);
            Console.WriteLine("\tDirectorio en el que se encuentra este directorio: " + windowsboot.Parent);
            Console.WriteLine("\tDirectorio raíz de este directorio:                " + windowsboot.Root);
            Console.WriteLine("\tAtributos del directorio:                          " + windowsboot.Attributes);
            Console.WriteLine("\tFecha de creación del directorio:                  " + windowsboot.CreationTime);
            Console.WriteLine("\tÚltimo acceso de lectura:                          " + windowsboot.LastAccessTime);
            Console.WriteLine("\tÚltimo acceso de escritura:                        " + windowsboot.LastWriteTime);

            Console.WriteLine("\n\tLista de archivos en el directorio:");
            FileInfo[] archivos = windowsboot.GetFiles();
            if (archivos.Length > 0)
            {
                foreach (var tmp in archivos)
                {
                    Console.WriteLine("\t\t" + tmp);
                }
            }
            else Console.WriteLine("\t\tNinguno");

            Console.WriteLine("\n\tLista de directorios en este directorio:");
            DirectoryInfo[] subdirectorios = windowsboot.GetDirectories();
            if (subdirectorios.Length > 0)
            {
                foreach (var tmp in subdirectorios)
                {
                    Console.WriteLine("\t\t" + tmp);
                }
            }
            else Console.WriteLine("\t\tNinguno");
            Console.ReadKey();

        }
    }
}
