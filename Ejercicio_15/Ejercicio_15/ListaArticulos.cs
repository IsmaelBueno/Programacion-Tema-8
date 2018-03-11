using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejercicio_15
{
    class ListaArticulos : IEnumerable , IEnumerator
    {
        //CAMPOS
        private  List<Articulo> _articulos = null;
        private int posicion = -1;

        //PROPIEDADES
        public int Length
        {
            get { return _articulos.Count; }
        }

        //CONSTRUCTOR
        public ListaArticulos()
        {
            _articulos = new List<Articulo>();
        }

        //METODOS
        public void OrdenarPorNombre()
        {
            _articulos.Sort(new OrdenarNom());
        }
        public void OrdenarPorCodigo()
        {
            _articulos.Sort(new OrdenarCod());
        }
        public void Listar()
        {
            Console.WriteLine(" Cod |          Nombre |             Precio |                PVP | Existencias");
            foreach (Articulo tmp in _articulos)
            {
                Console.WriteLine(tmp.VisualizarCodigoConFormato().PadLeft(4) + tmp.Nombre.PadLeft(18) + tmp.Precio.ToString().PadLeft(21) + tmp.Pvp.ToString().PadLeft(21) + tmp.Existencias.ToString().PadLeft(14));
            }
        }
        public void AnadirArticulo(Articulo a)
        {
            _articulos.Add(a);
        }
        public bool EliminarArticulo(int codigo)
        {
            foreach (Articulo tmp in _articulos)
            {
                if (tmp.Cod == codigo)
                {
                    _articulos.Remove(tmp);
                    return true;
                }
            }
            return false;
        }
        public bool ConsultarArticulo(int codigo)
        {
            foreach (Articulo tmp in _articulos)
            {
                if (tmp.Cod == codigo)
                {
                    Console.WriteLine("Codigo: " + tmp.VisualizarCodigoConFormato());
                    Console.WriteLine("Nombre: " + tmp.Nombre);
                    Console.WriteLine("Precio: " + tmp.Precio);
                    Console.WriteLine("PVP: " + tmp.Pvp);
                    Console.WriteLine("Existencias: " + tmp.Existencias);
                    Console.WriteLine("Comentario: " + tmp.Comentario);
                    return true;
                }
            }
            return false;
        }


        //Criterio para ordenar por codigo
        private class OrdenarCod : IComparer<Articulo>
        {
            public int Compare(Articulo x, Articulo y)
            {
                if (x.Cod > y.Cod) return 1;
                if (x.Cod < y.Cod) return -1;
                return 0;
            }
        }
        //Criterio para ordenar por nombre
        private class OrdenarNom : IComparer<Articulo>
        {

            public int Compare(Articulo x, Articulo y)
            {
                return string.Compare(x.Nombre,y.Nombre);
            }
        }

        //Interfaces
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public object Current
        {
            get { return _articulos[posicion]; }
        }
        public bool MoveNext()
        {
            if (posicion < _articulos.Count - 1)
            {
                posicion++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }
        public void Reset()
        {
            posicion = -1;
        }
    }
}
