using System;

namespace Hospital.App.Dominio

{
    public class SignoVital
    {
        public int Id {get;set;}
        public DateTime FechaHora {get;set;}
        public string Signo {get;set;}
        public double Valor {get;set;}
        public int PacienteId {get; set;}
    }
}
