using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Equipo
    {
        public int Id{get;set;}
        public string Nombre{get;set;}
        public string Disciplina{get;set;}
        public Entrenador Entrenador{get;set;}
        public int PatrocinadorId{get;set;}
        public List<TorneoEquipo> TorneoEquipos {get;set;}
        public List<Deportista> Deportistas {get;set;}
    }
}