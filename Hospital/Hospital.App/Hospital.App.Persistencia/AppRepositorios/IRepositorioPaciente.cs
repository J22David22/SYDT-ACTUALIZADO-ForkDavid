using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable <Paciente> GetAllPacientes();
        //IEnumerable<Paciente> GetPacientesPorFiltro(string filtro);
        
        Paciente AddPaciente (Paciente paciente);

        Paciente UpdatePaciente(Paciente paciente);

        public void DeletePaciente (int idPaciente);

        public Paciente GetPaciente(int idPaciente);
    }
}