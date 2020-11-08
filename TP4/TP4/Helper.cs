using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP4
{
    static class Helper
    {
        public static string NombreCadeteriaRandom()
        {
            string[] NombresCadeteriasR = { "Ocaranza Cadeteria", "Mariani Cadeteria" };
            Random r = new Random();
            int maximo = NombresCadeteriasR.Count();
            return NombresCadeteriasR[r.Next(maximo)];
        }
        public static int IdRandom()
        {
            Random r = new Random();
            return r.Next(10000, 100000);
        }
        public static string NombrePersonaRandom()
        {
            string[] NombresR = { "Carlos", "Jose", "Pedro", "Hernan", "Franco", "Maria", "Fernanda" };
            Random r = new Random();
            int maximo = NombresR.Count();
            return NombresR[r.Next(maximo)];
        }
        public static string DirecionesRandom()
        {
            string[] DireccionesR = { "Alberdi", "Muñecas", "Roca", "Jujuy" };
            Random r = new Random();
            int maximo = DireccionesR.Count();
            return DireccionesR[r.Next(maximo)];

        }
        public static string TelefonoRandom()
        {
            string[] TelefonosR = { "3814458789", "3811234565", "3815847965", "3816152478" , "3814459345" };
            Random r = new Random();
            int maximo = TelefonosR.Count();
            return TelefonosR[r.Next(maximo)];
        }
        public static VehiculoCadete VehiculoCadeteRandom()
        {
            Random r = new Random();
            int num = r.Next(3);
            if (num == 0)
                return VehiculoCadete.Auto;
            else if (num == 1)
                return VehiculoCadete.Moto;
            else
                return VehiculoCadete.Bicicleta;
        }
        public static TiposDePedidos TiposDePedidoRandom()
        {
            Random r = new Random();
            int num = r.Next(3);
            if (num == 0)
                return TiposDePedidos.Delicado;
            else if (num == 1)
                return TiposDePedidos.Express;
            else
                return TiposDePedidos.Ecologico;
        }
        public static string ObservacionRandom()
        {
            string[] obsR = { "---", "Urgente", "No hay apuro" };
            Random r = new Random();
            int maximo = obsR.Count();
            return obsR[r.Next(maximo)];
        }
        public static Cadeteria CrearCadeteria()
        {
            string nombre = Helper.NombreCadeteriaRandom();
            return new Cadeteria(nombre);
        }
        public static List<Cliente> CrearNClientes(int N)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            for (int i = 0; i < N; i++)
            {
                int id = Helper.IdRandom();
                string nombre = Helper.NombrePersonaRandom();
                string direccion = Helper.DirecionesRandom();
                string telefono = Helper.TelefonoRandom();                
                listaClientes.Add(new Cliente(id, nombre, direccion, telefono));
            }
            return listaClientes;
        }
        public static List<Cadete> CrearNCadetes(int N)
        {
            List<Cadete> listaCadetes = new List<Cadete>();
            for (int i = 0; i < N; i++)
            {
                int id = Helper.IdRandom();
                string nombre = Helper.NombrePersonaRandom();
                string direccion = Helper.DirecionesRandom();
                string telefono = Helper.TelefonoRandom();
                VehiculoCadete tipoVehiculo = Helper.VehiculoCadeteRandom();
                listaCadetes.Add(new Cadete(id, nombre, direccion, telefono, tipoVehiculo));
            }
            return listaCadetes;
        }

        public static List<Pedido> CrearNPedidos(int N, List<Cliente> miListaClientes)
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            Random r = new Random();            
            int ind;
            for (int i = 0; i < N; i++)
            {                
                int numeroPedido = r.Next(10000);
                string observacion = Helper.ObservacionRandom();
                bool estado = r.Next(2) == 0;
                TiposDePedidos tipoPedido = Helper.TiposDePedidoRandom();
                bool cuponDescuento = r.Next(2) == 0;
                ind = r.Next(miListaClientes.Count);                            
                listaPedidos.Add(new Pedido(numeroPedido, observacion, estado, tipoPedido, cuponDescuento, miListaClientes[ind]));
                miListaClientes[ind].CantidadPedidosRealizados++;
            }
            return listaPedidos;
        }

        public static List<Pedido> CrearNPedidos(int N, List<Cliente> miListaClientes, TiposDePedidos miTipoPedido)
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            Random r = new Random();
            int ind;
            for (int i = 0; i < N; i++)
            {
                int numeroPedido = r.Next(10000);
                string observacion = Helper.ObservacionRandom();
                bool estado = r.Next(2) == 0;                
                bool cuponDescuento = r.Next(2) == 0;
                ind = r.Next(miListaClientes.Count);
                listaPedidos.Add(new Pedido(numeroPedido, observacion, estado, miTipoPedido, cuponDescuento, miListaClientes[ind]));
                miListaClientes[ind].CantidadPedidosRealizados++;
            }
            return listaPedidos;
        }

        public static void AsignarPedidosUnCadete (List<Pedido> listaPedidos, Cadete miCadete)
        {
            foreach (Pedido pedidoX in listaPedidos)
            {
                miCadete.AgregarPedido(pedidoX);
            }
        }

        public static void AsignarPedidos (List<Pedido> listaPedidos, List<Cadete> listaCadetes)
        {
            int ind = listaCadetes.Count;
            int rand;
            List<Pedido>[] listaDeListasPedidos = Enumerable.Range(0, ind).Select(n => new List<Pedido>()).ToArray();                        
            Random r = new Random();
            foreach (Pedido pedidoX in listaPedidos)
            {               
                rand = r.Next(0, ind);
                listaDeListasPedidos[rand].Add(pedidoX); 
            }                        
            for (int i = 0; i < ind; i++)
            {               
                Helper.AsignarPedidosUnCadete(listaDeListasPedidos[i], listaCadetes[i]);
            }
        }

        public static bool VerificarPedido (TiposDePedidos tipoPedido, VehiculoCadete vehiculo)
        {
            if (tipoPedido == TiposDePedidos.Delicado && vehiculo == VehiculoCadete.Auto)
                return true;
            if (tipoPedido == TiposDePedidos.Express && vehiculo == VehiculoCadete.Moto)
                return true;
            if (tipoPedido == TiposDePedidos.Ecologico && vehiculo == VehiculoCadete.Bicicleta)
                return true;
            return false;
        }

        public static void AsignarPedidosDeUnTipo(List<Pedido> listaPedidos, List<Cadete> listaCadetes)
        {
            int ind = listaCadetes.Count;
            int rand;            
            Random r = new Random();
            foreach (Pedido pedidoX in listaPedidos)
            {
                for (int i = 0; i < ind; i++)
                {
                    rand = r.Next(0, ind);
                    if (Helper.VerificarPedido(pedidoX.TipoPedido, listaCadetes[rand].TipoVehiculo))
                        listaCadetes[rand].AgregarPedido(pedidoX);
                }                             
            }            
        }

            public static void AsignarCadetesACadeteria(List<Cadete> miListaCadetes, Cadeteria miCadeteria)
        {
            foreach (Cadete cadeteX in miListaCadetes)
            {
                miCadeteria.AgregarCadete(cadeteX);
            }
        }

        public static void ImprimirInforme(string informe)
        {
            Console.WriteLine(informe);
        }
    }
}
