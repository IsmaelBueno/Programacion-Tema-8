using System;
using System.Collections.Generic;
using System.IO;

namespace Ejercicio_14
{
    class Program
    {
        //Para poder arrancar este programa desde la cmd de windows, hay que ir a settings, en el buscador escribimos variables, le damos a (edit the system env... variables)
        //a continuacion en la pestaña advance enviroment variables y en path le damos a edit y añadimos la nueva ruta que tenga en cuenta
        static void Main(string[] args)
        {
            string rutaDefecto = "./"; //Ruta por defecto para algunos comandos

            if (args.Length > 0)
            {
                switch (args[0].ToUpper())
                {
                    case "AYUDA":
                        if (args.Length == 1) Ayuda();
                        else Error();
                        break;
                    case "DIR":
                        if (args.Length == 1) Dir(rutaDefecto);
                        else if (args.Length == 2) Dir(args[1]);
                        else Error();
                        break;
                    case "COPIAR":
                        if (args.Length > 2) Copiar(args);
                        else Error();
                        break;
                    case "MOSTRAR":
                        if (args.Length == 2) Mostrar(args[1]);
                        else Error();
                        break;
                    case "BUSCAR":
                        if (args.Length == 3) Buscar(args[1], args[2]);
                        else Error();
                        break;
                    default:
                        Error();
                        break;
                }
            }
            else Error();
        }

        static void Error()
        {
            Console.WriteLine("Algunos argumentos no son correctos, para obtener información usa el comando AYUDA");
        }
        static void Ayuda()
        {
            //Comandos
            Console.WriteLine("\nAYUDA");
            Console.WriteLine("Información sobre los comnados de Midos");
            Console.WriteLine("\nDIR [ruta]");
            Console.WriteLine("Muestra los subdirectorios y ficheros de la ruta actual o en caso de darle una ruta la ruta dada");
            Console.WriteLine("\nCOPIAR (DirOrigen(fichero)) (DirDestino)");
            Console.WriteLine("Copia un/unos fichero/s especificado/s otro directorio");
            Console.WriteLine("\nMOSTRAR (ruta)");
            Console.WriteLine("Muestra por pantalla el contenido de un archivo de texto");
            Console.WriteLine("\nBUSCAR (\"cadena\") (ruta)");
            Console.WriteLine("Busca una cadena de texto en un archivo específico");
        }
        static void Dir(string ruta)
        {
            if(!Directory.Exists(ruta))
            {
                Console.WriteLine("Imposible encontrar la ruta");
                return;
            }
            string[] directorios = Directory.GetDirectories(ruta);
            string[] archivos = Directory.GetFiles(ruta);
            for (int i = 0; i < directorios.Length; i++)
            {
                Console.WriteLine(directorios[i]);
            }
            for (int i = 0; i < archivos.Length; i++)
            {
                Console.WriteLine(archivos[i]);
            }
        }
        static void Copiar(string[] args)
        {
            string rutadestino = args[args.Length - 1];
            Queue<string> errores = new Queue<string>();

            //Comprueba la ruta de destino
            if(!Directory.Exists(rutadestino))
            {
                Console.WriteLine("Imposible encontrar la ruta de destino");
                return;
            }

            //Comprobar que existe el archivo antes de copiarlo y si existe luego copiarlo, en caso de no encontrarlo no hara nada y pasara al siguiente
            for (int i = 1; i < args.Length-1; i++)//Empieza desde uno para que ignore "COPIAR" y acaba antes en length-1 porque es el destino
            {
                if (File.Exists(args[i]))
                {
                    File.Copy(args[i], rutadestino + "/" + Path.GetFileNameWithoutExtension(args[i]) + "Copia" + Path.GetExtension(args[i]), true);
                }
                else errores.Enqueue(args[i]);
            }
            if(errores.Count>0) 
            {
                Console.WriteLine("Los siguientes archivos no se pudieron encontrar:");
                foreach (string tmp in errores)
                    Console.WriteLine(tmp);
            }
        }
        static void Mostrar(string ruta) 
        {
            if (!File.Exists(ruta))
            {
                Console.WriteLine("Imposible encontrar el archivo");
                return;
            }

            string contenido;

            using (StreamReader lectura = new StreamReader(ruta))
            {
                contenido = lectura.ReadToEnd();    
            }

            Console.WriteLine(contenido);
        }
        static void Buscar(string cadena, string ruta)
        {
            if (!File.Exists(ruta))
            {
                Console.WriteLine("Imposible encontrar el archivo");
                return;
            }

            string contenido;
            using (StreamReader lector  = new StreamReader(ruta))
            {
                contenido = lector.ReadToEnd();
            }

            if(contenido.Contains(cadena)) Console.WriteLine("La cadena se encuentra en el archivo especificado");
            else Console.WriteLine("La cadena no se encuentar en el archivo especificado");
        }
    }
}
