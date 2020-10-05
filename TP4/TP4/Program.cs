using System;
using System.Collections.Generic;

namespace TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            Cadeteria miCadeteria = Helper.CrearCadeteria();
            List<Cadete> miListaCadetes = Helper.CrearNCadetes(3);
            List<Cliente> miListaClientes = Helper.CrearNClientes(3);
            List<Pedido> miListaPedidos1 = Helper.CrearNPedidos(20, miListaClientes);
            Helper.AsignarPedidos(miListaPedidos1, miListaCadetes);
            Helper.AsignarCadetesACadeteria(miListaCadetes, miCadeteria);
            Helper.ImprimirInforme(miCadeteria.InformeEntregasRealizadas());
            Helper.ImprimirInforme(miCadeteria.InformeMejorCadete());
            Helper.ImprimirInforme(miCadeteria.InformePromedioPedidos());
        }
    }
}
