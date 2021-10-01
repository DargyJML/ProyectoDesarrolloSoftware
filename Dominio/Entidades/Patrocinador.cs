using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Patrocinador
    {
        public int Id{get;set;}
        public string Nombres{get;set;}
        public string Apellidos{get;set;}
        public string Identificacion{get;set;}
        public string TipoPersona{get;set;}
        public string Telefono{get;set;}
        public string Direccion{get;set;}
        public string Email{get;set;}
        public List<Equipo> Equipos{get;set;}
    }
}