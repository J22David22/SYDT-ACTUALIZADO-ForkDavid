using System;

namespace Hospital.App.Dominio
{



public class HistoriaClinica
{
    public int Id {get;set;}
    public string? Diagnostico {get;set;}
    public string? Entorno {get;set;}
    public int PacienteId {get; set;}
    public int MedicoId {get; set;}
    //public SugerenciasCuidado SugerenciasCuidado {get;set;}
    

}

}