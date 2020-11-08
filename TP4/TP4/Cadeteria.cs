using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    static class constantes
    {
        public const int PRECIO_PEDIDO = 150;

        public static double CalcularPrecioJornal(VehiculoCadete vehiculo)
        {
            double costo = constantes.PRECIO_PEDIDO;
            if (vehiculo == VehiculoCadete.Moto)
                costo *= 1.20;
            else if (vehiculo == VehiculoCadete.Auto)
                costo *= 1.25;
            else
                costo *= 1.05;            
            return costo;
        }
    }
    class Cadeteria
    {

        public string Nombre { get ; set ; }
        public List<Cadete> ListaCadetes { get ; set; }

        public Cadeteria(string nombre)
        {
            Nombre = nombre;
            ListaCadetes = new List<Cadete>();
        }

        public void AgregarCadete(Cadete nuevoCadete)
        {
            ListaCadetes.Add(nuevoCadete);
        }

        public double PagoCadete(Cadete cad)
        {            
            return cad.CantidadPedidosRealizados() * constantes.CalcularPrecioJornal(cad.TipoVehiculo);
        }
        public string InformeUnCadete(Cadete cadeteX)
        {
            string informe = "";
            informe += "Nombre: " + cadeteX.Nombre;
            informe += "\nVehiculo: " + cadeteX.TipoVehiculo.ToString();            
            informe += "\nCantidad de pedidos: " + cadeteX.CantidadPedidosRealizados();          
            informe += "\nJornal del cadete: $" + this.PagoCadete(cadeteX) + "\n\n";
            return informe;
        }

        public string InformeEntregasRealizadas()
        {
            string informe = "";
            foreach (Cadete cadeteX in ListaCadetes)
            {
                informe += InformeUnCadete(cadeteX);
            }
            return informe;
        }

        public string InformeMejorCadete()
        {
            string informe = "El cadete que mas pedidos entrego fue:\n";
            int mayor = -1;
            Cadete mejorCadete = null;
            foreach (Cadete cadeteX in ListaCadetes)
            {
                if (cadeteX.CantidadPedidosRealizados() > mayor)
                {
                    mejorCadete = cadeteX;
                    mayor = cadeteX.CantidadPedidosRealizados();
                }
            }
            informe += InformeUnCadete(mejorCadete);
            return informe;
        }

        public string InformePromedioPedidos()
        {
            string informe = "El promedio de pedidos entregados es: ";
            double acumulador = 0.00;
            double promedio = 0.00;
            int cantPedidos = 0;
            foreach (Cadete cadeteX in ListaCadetes)
            {
                acumulador += cadeteX.CantidadPedidosRealizados();
                cantPedidos += cadeteX.CalculaCantidadPedidos();
            }
            promedio = acumulador / cantPedidos;
            informe += promedio;
            return informe;
        }
    }
}
