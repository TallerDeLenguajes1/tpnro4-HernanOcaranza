using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    class Pedido
    {
        public int NumeroPedido { get ; set ; }
        public string Observacion { get ; set ; }
        public bool Estado { get ; set ; }
        public Cliente Cliente { get ; set ; }

        public Pedido(int numeroPedido, string observacion, bool estado, Cliente C)
        {
            NumeroPedido = numeroPedido;
            Observacion = observacion;
            Cliente = C;
            Estado = estado;
        }
    }
}
