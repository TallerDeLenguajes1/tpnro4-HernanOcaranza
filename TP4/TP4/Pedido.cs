using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    enum TiposDePedidos
    {
        Express,
        Delicado,
        Ecologico
    }
    class Pedido
    {
        public int NumeroPedido { get ; set ; }
        public string Observacion { get ; set ; }
        public bool Estado { get ; set ; }
        public Cliente Cliente { get ; set ; }
        public TiposDePedidos TipoPedido { get; set; }

        public bool CuponDescuento { get; set; }

        public double CostoPedido { get; set; }

        private double CalcularCostoPedido()
        {
            double costo = constantes.PRECIO_PEDIDO;
            if (TipoPedido == TiposDePedidos.Express)
                costo *= 1.25;
            else if (TipoPedido == TiposDePedidos.Delicado)
                costo *= 1.3;
            if (CuponDescuento)
                costo *= 0.9;
            return costo;
        }
        public Pedido(int numeroPedido, string observacion, bool estado, TiposDePedidos tipoPedido, bool cuponDescuento, Cliente C)
        {
            NumeroPedido = numeroPedido;
            Observacion = observacion;
            Cliente = C;
            Estado = estado;
            TipoPedido = tipoPedido;
            CuponDescuento = cuponDescuento;
            CostoPedido = CalcularCostoPedido();
        }
    }
}
