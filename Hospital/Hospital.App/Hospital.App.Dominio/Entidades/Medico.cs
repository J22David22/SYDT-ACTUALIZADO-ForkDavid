using System;

namespace Hospital.App.Dominio
{
    public class Medico: Persona
    {
        public string Especialidad {get;set;}
        public string Codigo {get;set;}
        public string RegistroRethus {get;set;}
        public List<Paciente> Pacientes {get;set;}

    }
}