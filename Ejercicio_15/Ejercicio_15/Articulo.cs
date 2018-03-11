using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejercicio_15
{
    class Articulo
    {
        //CAMPOS
        private int _cod;
        private string _nombre;
        private float _precio;
        private float _pvp;
        private int _existencias;
        private string _comentario;    
        private const int LONGITUDMAXIMANOMBRE = 15;
        private const int LONGITUDMAXIMACOMENTARIO = 50;
        private const int IVA_PORCENTAJE = 25;
        private static int _codactual = 0;

        //PROPIEDADES
        public int Cod//autocalculado al crear un nuevo artículo
        {
            get { return _cod; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set 
            {
                if (value.Length > LONGITUDMAXIMANOMBRE)
                {
                    string nombrelimitado = string.Empty;
                    for (int i = 0; i < LONGITUDMAXIMANOMBRE; i++)
                    {
                        nombrelimitado += value[i];
                    }
                    _nombre = nombrelimitado;
                }
                else _nombre = value; 
            }
        }
        public float Precio
        {
            get { return _precio; }
            set 
            {
                if (value < 0) _precio = 0; //El precio no puedes ser negativo   
                    else  _precio = value;
                _pvp = CalcularPVP(); //Aqui calcula el pvp cada vez que se ajusta el precio
            }
        }
        public float Pvp//autocalculado a partir del precio
        {
            get { return _pvp; }
        }
        public int Existencias
        {
            get { return _existencias; }
            set 
            {
                if (value < 0) _existencias = 0; //Las existencias no pueden ser negativas
                    else _existencias = value;
            }
        }
        public string Comentario
        {
            get { return _comentario; }
            set
            {
                if (value.Length > LONGITUDMAXIMACOMENTARIO)
                {
                    string comentariolimitado = string.Empty;
                    for (int i = 0; i < LONGITUDMAXIMACOMENTARIO; i++)
                    {
                        comentariolimitado += value[i];
                    }
                    _comentario = comentariolimitado;
                }
                else _comentario = value;
            }
        }


        //CONSTRUCTOR
        public Articulo(string n, float p, int e, string c)
        {
            Nombre = n;
            Precio = p;
            Existencias = e;
            Comentario = c;
            _cod = CalcularCod();
        }

        //METODOS PRIVADOS
        private float CalcularPVP()
        {
            return (_precio * IVA_PORCENTAJE / 100) + _precio;
        }
        private static int CalcularCod()
        {
            if (_codactual < 999) return _codactual++;
            else throw new Exception("Máximo número de artículos (999)");
        }

        //METODOS PUBLICOS
        public string VisualizarCodigoConFormato()
        {
            return string.Format("{0}".PadLeft(5,'0'),Cod);
        }

    }
}
