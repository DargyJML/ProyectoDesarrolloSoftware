using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Arena
    {
        public int Id{get;set;}
        public string Nombre{get;set;}
        public string Disciplina{get;set;}
        public string Estado{get;set;}
        public int CapacidadEspectadores{get;set;}
        public string Dimensiones{get;set;}
        public int EscenarioId{get;set;}
    }
}