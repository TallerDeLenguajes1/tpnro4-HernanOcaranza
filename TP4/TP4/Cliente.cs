using System;
using System.Collections.Generic;
using System.Text;
using TP4;

namespace TP4
{
    class Cliente : Persona
    {
        public int CantidadPedidosRealizados { get; set; }
        public Cliente(int id, string nombre, string direccion, string telefono): base(id, nombre, direccion, telefono)
        {
            CantidadPedidosRealizados = 0;
        }

        public Cliente(Cliente C) : base(C)
        {
            CantidadPedidosRealizados = C.CantidadPedidosRealizados;
        }

        public override int CalculaCantidadPedidos()
        {
            return CantidadPedidosRealizados;
        }





    }
}
