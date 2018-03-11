using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Ejercicio_15
{
    class Program
    {
        static ConsoleKeyInfo opcion;
        static ListaArticulos articulos = new ListaArticulos();
        static string ruta = @"./articulos.txt";

        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 15";
            bool salir = false;
            bool salirconfirmacion = false;          
            int articulobuscado = 0;

            do
            {
                Console.SetCursorPosition(0,0);
                ImprimirMenu();

                opcion = Console.ReadKey();

                switch (opcion.Key)
                {
                    #region alta articulo
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Precio: ");
                        float precio = FloatTeclado();
                        Console.Write("Existencias: ");
                        int exist = IntTeclado();
                        Console.Write("Comentario: ");
                        string comentario = Console.ReadLine();
                        articulos.AnadirArticulo(new Articulo(nombre,precio,exist,comentario));
                        Console.Clear();
                        break;
                    #endregion
                    #region Baja articulo
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Introduce el código del artículo que quieres borrar");
                        articulobuscado = IntTeclado();

                        if (articulos.ConsultarArticulo(articulobuscado))
                        {
                            salirconfirmacion=false;
                            Console.WriteLine("\n¿Seguro que quieres borrar este artículo? (s/n)");
                            do
                            {
                                opcion = Console.ReadKey();
                                switch (opcion.Key)
                                {
                                    case ConsoleKey.S:
                                        articulos.EliminarArticulo(articulobuscado);
                                        salirconfirmacion = true;
                                        break;
                                    case ConsoleKey.N:
                                        salirconfirmacion = true;
                                        break;
                                }
                            } while (!salirconfirmacion);               
                        }
                        else Console.WriteLine("El código de artículo introducido no coincide con ningún artículo existente...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    #endregion
                    #region Consultar articulo
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Introduce el código del artículo que quieres consultar");
                        if (articulos.ConsultarArticulo(IntTeclado())) Console.WriteLine("\n\n\nPulsa cualquier tecla para volver...");
                            else Console.WriteLine("El código de artículo introducido no coincide con ningún artículo existente...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    #endregion
                    #region Modificar articulo
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Introduce el código del artículo que quieres modificar");
                        articulobuscado = IntTeclado();
                        if (articulos.ConsultarArticulo(articulobuscado))
                        {
                            Console.Clear();
                            ModificarArticulo(articulobuscado);
                        }
                        else
                        {
                            Console.WriteLine("El código de artículo introducido no coincide con ningún artículo existente...");
                            Console.ReadKey();
                        }
                        Console.Clear();
                        break;
                    #endregion
                    #region Listar articulos por codigo
                    case ConsoleKey.D5:
                        Console.Clear();
                        articulos.OrdenarPorCodigo();
                        articulos.Listar();
                        Console.WriteLine("\n\n\nPulsa cualquier tecla para volver...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    #endregion
                    #region Listar articulos por nombre
                    case ConsoleKey.D6:
                        Console.Clear();
                        articulos.OrdenarPorNombre();
                        articulos.Listar();
                        Console.WriteLine("\n\n\nPulsa cualquier tecla para volver...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    #endregion
                    #region Imprimir fichero
                    case ConsoleKey.D7:
                        Console.Clear();
                        ImprimirFichero();
                        Console.WriteLine("\n\n\nPulsa cualquier tecla para volver...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    #endregion
                    case ConsoleKey.D8:
                        Console.Clear();
                        Console.WriteLine("Estamos trabajando en ello :D");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    #region Generar fichero
                    case ConsoleKey.D9:
                        Console.Clear();
                        Comrpobarfichero();
                        Console.Clear();
                        break;
                    #endregion
                    case ConsoleKey.D0:
                        salir = true;
                        break;
                    case ConsoleKey.Escape:
                        salir = true;
                        break;
                }

            } while (!salir);
        }

        static void ImprimirMenu()
        {
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                   MENU PRINCIPAL                                    ║");
            Console.WriteLine("╠══════════════════════════════════════════╦══════════════════════════════════════════╣");
            Console.WriteLine("║ [1] Alta de artículos                    ║ [6] Listar artículos ordenado por nombre ║");
            Console.WriteLine("║ [2] Baja de artículos                    ║ [7] Imprimir                             ║");
            Console.WriteLine("║ [3] Consulta un artículo                 ║ [8] Generar documento HTML               ║");
            Console.WriteLine("║ [4] Modificar un artículo                ║ [9] Crear fichero                        ║");
            Console.WriteLine("║ [5] Listar artículos ordenado por código ║ [0] Salir                                ║");
            Console.WriteLine("╚══════════════════════════════════════════╩══════════════════════════════════════════╝");
            Console.Write("     TECLA PULSADA: ");
        }
        static int IntTeclado()
        {
            bool salir = false;
            int numero;
            do
            {
                salir = int.TryParse(Console.ReadLine(), out numero);
                if (!salir) Console.WriteLine("Debes introducir un número entero");
            } while (!salir);
            return numero;
        }
        static float FloatTeclado()
        {
            bool salir = false;
            float numero;
            do
            {
                salir = float.TryParse(Console.ReadLine(), out numero);
                if (!salir) Console.WriteLine("Debes introducir un número decimal");
            } while (!salir);
            return numero;
        }
        static void ModificarArticulo(int codigo)
        {
            //ADVERTENCIA!!! esto es codigo espagueti, pero hecho con mucho cariño :D, cualquier duda consultarme
            bool salirsubmenu = false;
            bool limpiarpantalla = false;
            const int X = 1;
            int y = 0;
            Console.CursorVisible = false;


            foreach (Articulo tmp in articulos)
            {
                if (tmp.Cod == codigo)
                {
                    do
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("   Nombre (Actualmente: {0})", tmp.Nombre); //y = 0
                        Console.WriteLine("   Precio (Actualmente: {0})", tmp.Precio); //y = 1
                        Console.WriteLine("   Existencia (Actualmente: {0})", tmp.Existencias); //y = 2
                        Console.WriteLine("   Comentario (Actualmente: {0})", tmp.Comentario); //y = 3
                        Console.WriteLine("   Salir");    //y = 4
                        Console.WriteLine("\n\nSelecciona que quieres modificar");

                        Console.SetCursorPosition(X, y);
                        Console.Write("»");
                        opcion = Console.ReadKey();

                        switch (opcion.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (y == 0) y = 4;
                                else y--;
                                break;
                            case ConsoleKey.DownArrow:
                                if (y == 4) y = 0;
                                else y++;
                                break;
                            case ConsoleKey.Enter:
                                limpiarpantalla = true;
                                switch (y)
                                {
                                    case 0:
                                        Console.Clear();
                                        Console.WriteLine("Escribe el nuevo nombre");
                                        tmp.Nombre = Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Escribe el nuevo precio");
                                        tmp.Precio = FloatTeclado();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Escribe la nueva cantidad de existencias");
                                        tmp.Existencias = IntTeclado();
                                        Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("Escribe el nuevo comentario");
                                        tmp.Comentario = Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 4:
                                        salirsubmenu = true;
                                        break;
                                }
                                break;
                        }
                        if (limpiarpantalla)
                        {
                            Console.Clear();
                            limpiarpantalla = false;
                        }
                    } while (!salirsubmenu);
                    Console.CursorVisible = true;
                    return;
                }
            }
        }
        static void CrearFichero()
        {
            using (FileStream f = new FileStream(ruta, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter escr = new StreamWriter(f))
                {
                    foreach (Articulo tmp in articulos)
                    {
                        escr.WriteLine("Codigo: " + tmp.VisualizarCodigoConFormato());
                        escr.WriteLine("Nombre: " + tmp.Nombre);
                        escr.WriteLine("Precio: " + tmp.Precio);
                        escr.WriteLine("PVP: " + tmp.Pvp);
                        escr.WriteLine("Existencias: " + tmp.Existencias);
                        escr.WriteLine("Comentario: " + tmp.Comentario);
                        escr.WriteLine("-".PadLeft(70, '-'));
                    }
                }
            }
        }
        static void Comrpobarfichero()
        {           
            bool salirconfirmacion = false;

            if (File.Exists(ruta))
            {
                Console.WriteLine("Ya existe un archivo artículos.txt, ¿Quieres sobreescribirlo? (s/n)");
                salirconfirmacion = false;
                do
                {
                    opcion = Console.ReadKey();
                    switch (opcion.Key)
                    {
                        case ConsoleKey.S:
                            CrearFichero();
                            salirconfirmacion = true;
                            break;
                        case ConsoleKey.N:
                            salirconfirmacion = true;
                            break;
                    }
                } while (!salirconfirmacion);
            }
            else CrearFichero();
        }
        static void ImprimirFichero()
        {
            if (!File.Exists(ruta)) Console.WriteLine("No se pudo encontrar el fichero articulos.txt");
            else 
            {
                string contenido = string.Empty;
                using (StreamReader lec = new StreamReader(ruta))
                {
                    contenido = lec.ReadToEnd();
                }
                Console.Write(contenido);
            }
        }
    }
}
