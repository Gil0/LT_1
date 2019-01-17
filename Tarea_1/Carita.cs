using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_1;

namespace Tarea_1
{
    public class Carita
    {
        private string nombre;
        private int x;
        private int y;
        private int radio;
        private string modo;

        public Carita(string nombre, int x, int y, int radio, string modo)
        {
            this.Nombre = nombre;
            this.X = x;
            this.Y = y;
            this.Radio = radio;
            this.Modo = modo;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Radio { get => radio; set => radio = value; }
        public string Modo { get => modo; set => modo = value; }

        public void DibujarCara(Carita cara)
        {

        }

        public void EliminarCara(Carita cara)
        {

        }

        public void CambiarModo(string nuevomodo)
        {

        }
    }
}
