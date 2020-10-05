using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TP4
{
    class Cadete : Persona
    {
        public List<Pedido> ListadoPedidos { get ; set ; }

        public Cadete(int id, string nombre, string direccion, string telefono): base(id, nombre, direccion, telefono)
        {
            ListadoPedidos = new List<Pedido>();
        }
        public Cadete(Cadete C) : base(C)
        {
            ListadoPedidos = C.ListadoPedidos;
        }

        public void AgregarPedido(Pedido nuevoPedido)
        {
            ListadoPedidos.Add(nuevoPedido);
        }

        public override int CalculaCantidadPedidos()
        {
            int cant = 0;
            foreach (Pedido pedidoX in ListadoPedidos)
            {
                if (pedidoX.Estado)
                    cant++;
            }
            return cant;
        }
    }
}
