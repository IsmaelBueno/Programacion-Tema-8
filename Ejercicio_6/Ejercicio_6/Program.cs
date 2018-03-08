using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 6";
            string ruta = @"c:/basura/salida.txt";
            char caracter = 'h';
            int resultado;

            using (FileStream f = new FileStream(ruta,FileMode.Open,FileAccess.Read))
            {
                resultado = ContadorCaracterFichero(caracter, f);
            }

            Console.WriteLine("El caracter \"{0}\" aparece {1} veces",caracter,resultado);
            Console.ReadKey();

        }

        static int ContadorCaracterFichero(char c, FileStream f)
        {
            //Lectura del fichero
            StreamReader lectura = new StreamReader(f);
            string contenido = lectura.ReadToEnd();
            lectura.Close();

            //Contar el caracter en el contenido
            int nVeces = 0;
            for (int i = 0; i < contenido.Length; i++)
            {
                if (contenido[i] == c) nVeces++;
            }

            return nVeces;
        }
    }
}
