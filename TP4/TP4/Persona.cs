using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Persona(int id, string nombre, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        public Persona(Persona P)
        {
            Id = P.Id;
            Nombre = P.Nombre;
            Direccion = P.Direccion;
            Telefono = P.Telefono;
        }
        public virtual int CalculaCantidadPedidos()
        {
            return 0;
        }
    }
}
