using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Personal
    {
        public int Id{get;set;}
        public string Nombres{get;set;}
        public string Apellidos{get;set;}
        public string Identificacion{get;set;}
        public string Labor{get;set;}
        public string EntidadResponsable{get;set;}
        public string Telefono{get;set;}
        public string Direccion{get;set;}    
        public string Email{get;set;}
        public string Rh{get;set;}
        public DateTime FechaNacimiento{get;set;}
        public int TorneoId{get;set;}
    }
}