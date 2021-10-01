using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Torneo
    {
        public int Id{get;set;}
        public string Nombre{get;set;}
        public string Categoria{get;set;}
        public DateTime FechaInicio{get;set;}
        public DateTime FechaFin{get;set;}
        public string TipoTorneo{get;set;}
        public int MunicipioId{get;set;}
        public List<TorneoEquipo> TorneoEquipos {get;set;}
        public List<Escenario> Escenarios {get;set;}
        public List<Personal> Personals {get;set;}
    }
}