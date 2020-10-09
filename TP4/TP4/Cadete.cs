using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TP4
{
    public enum VehiculoCadete
    {
        Bicicleta = 0,
        Auto = 1,
        Moto = 2
    }
    class Cadete : Persona
    {
        public VehiculoCadete TipoVehiculo { get ; set ; }
        public List<Pedido> ListadoPedidos { get ; set ; }
        
        public Cadete(int id, string nombre, string direccion, string telefono, VehiculoCadete vehiculoCadete): base(id, nombre, direccion, telefono)
        {
            TipoVehiculo = vehiculoCadete;
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
            return ListadoPedidos.Count;
        }

        public int CantidadPedidosRealizados()
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
