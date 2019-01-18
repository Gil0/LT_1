using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_1
{
    public class Instruccion
    {
        private string instruccion;
        private int tiempo;
        private Carita cara;
        private bool estado;


        public Instruccion(string instruccion, int tiempo, Carita cara, bool estado)
        {
            this.Instrucciones = instruccion;
            this.Tiempo = tiempo;
            this.Cara = cara;
            this.Estado = estado;
        }

        public string Instrucciones { get => instruccion; set => instruccion = value; }
        public Carita Cara { get => cara; set => cara = value; }
        public int Tiempo { get => tiempo; set => tiempo = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
