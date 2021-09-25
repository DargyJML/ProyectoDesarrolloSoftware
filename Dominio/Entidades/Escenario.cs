using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Escenario
    {
        public int Id{get;set;}
        public string Nombre{get;set;}
        public string Direccion{get;set;}
        public string Telefono{get;set;}
        public string Horario{get;set;}
        public int CapacidadEspectadores{get;set;}
        public int TorneoId{get;set;}
        public List<Arena> Arenas {get;set;}
    }
}