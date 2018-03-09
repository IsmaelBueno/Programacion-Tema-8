using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EjercicioValidadorUsuarioContrasenia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Validador usuario y contraseña";


            string ruta = @"./UsersPasswords.txt"; //ruta donde se encuentra el fichero
            char separador = ';'; //Caracter como criterio de separación
            string contenido = string.Empty;
            string[] contenidoSeparado = null;
            Dictionary<string, string> usuarios = new Dictionary<string,string>();


            //Comprobar que la ruta es correcta
            if (!File.Exists(ruta))
            {
                Console.WriteLine("Imposible encontrar el documento, comprueba la ruta");
                Console.ReadKey();
                return;
            }


            //Lectura del fichero
            using (StreamReader lectura = new StreamReader(ruta))
            {
                contenido = lectura.ReadToEnd();
            }

            //El método split separa un string en un array de string usando como criterio el caracter que se le de
            contenidoSeparado = contenido.Split(separador);

            //Llenamos el diccionario con los datos del string
            for (int i = 0; i < contenidoSeparado.Length; i++)
            {
                usuarios.Add(contenidoSeparado[i], contenidoSeparado[++i]);
            }

            //----------------------------------------------------------------------------------------------------------------------------
            //HASTA AQUI LA PARTE DE RECONOCER LOS DATOS DEL FICHERO Y GRABARLOS EN UN DICCIONARIO REFERENCIANDO 
            //AL USUARIO CON SU CLAVE Y USANDO EL USUARIO COMO CLAVE PRIMARIA
            //----------------------------------------------------------------------------------------------------------------------------
            string usuario;
            string contrasenia;

            Console.WriteLine("\tINICIO SESION");
            Console.Write("Usuario: ");
            usuario = Console.ReadLine();
            Console.Write("Contraseña: ");
            contrasenia = Console.ReadLine();

            if (usuarios.ContainsKey(usuario))      //El método ConstainsKey comprueba si en el diccinario se encuentra la clave que se le da como parametro
            {
                if (usuarios[usuario] == contrasenia) //En el diccionario si le das un valor entre corchetes y lo igualas a otro valor, significa que el valor entre corchetes comprobará si tiene el valor que le corresponde en esa posición
                {
                    Console.Clear();
                    Console.WriteLine("Sesión iniciada correctamente");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("La contraseña no coincide con el usuario introducido");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El usuario introducido no existe");
            }

            Console.ReadKey();
        }
    }
}
