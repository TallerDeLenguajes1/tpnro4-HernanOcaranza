using System;
using System.Collections.Generic;

namespace TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            Cadeteria miCadeteria = Helper.CrearCadeteria();
            List<Cadete> miListaCadetes = Helper.CrearNCadetes(4);
            List<Cliente> miListaClientes = Helper.CrearNClientes(3);
            List<Pedido> miListaPedidosDe = Helper.CrearNPedidos(10, miListaClientes, TiposDePedidos.Delicado);
            List<Pedido> miListaPedidosEx = Helper.CrearNPedidos(10, miListaClientes, TiposDePedidos.Express);
            List<Pedido> miListaPedidosEc = Helper.CrearNPedidos(10, miListaClientes, TiposDePedidos.Ecologico);
            Helper.AsignarPedidosDeUnTipo(miListaPedidosDe, miListaCadetes);
            Helper.AsignarPedidosDeUnTipo(miListaPedidosEx, miListaCadetes);
            Helper.AsignarPedidosDeUnTipo(miListaPedidosEc, miListaCadetes);
            Helper.AsignarCadetesACadeteria(miListaCadetes, miCadeteria);
            Helper.ImprimirInforme(miCadeteria.InformeEntregasRealizadas());
            Helper.ImprimirInforme(miCadeteria.InformeMejorCadete());
            Helper.ImprimirInforme(miCadeteria.InformePromedioPedidos());
        }
    }
}
