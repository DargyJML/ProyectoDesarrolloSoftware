using System;
using System.Collections.Generic;

namespace Dominio
{
    public class TorneoEquipo
    {
        public int TorneoId{get;set;}
        public int EquipoId{get;set;}
        public Torneo Torneo {get;set;} 
        public Equipo Equipo {get;set;} 
    }
}