using System;
using Hospital.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        //Conectar a la BDs

        private readonly AppContext _appContext;

        public RepositorioPaciente()
        {
            
        }
        public RepositorioPaciente (AppContext appContext)
        {
            this._appContext = appContext;
        }
        public Paciente AddPaciente(Paciente paciente)
        {
            // configuramos el ambiente para adicionar un usuario a la BD
            var pacienteAdicionada = _appContext.Pacientes.Add(paciente);
            // guardar la información en la BD
            _appContext.SaveChanges();

            return pacienteAdicionada.Entity;
        }
        public void DeletePaciente(int idPaciente)
        {
            var pacienteAEliminar=_appContext.Pacientes.FirstOrDefault(m => m.Id == idPaciente);

            /* select*from medico where u.Id = idmedico */

            if (pacienteAEliminar !=null)
            {
                _appContext.Pacientes.Remove(pacienteAEliminar);
                _appContext.SaveChanges();
            }
        }
        public Paciente GetPaciente (int idPaciente)
        {
           return _appContext.Pacientes.FirstOrDefault( m => m.Id == idPaciente);
        }
        public IEnumerable<Paciente> GetAllPacientes()
        {
            return _appContext.Pacientes;
        }

        /*public IEnumerable<Paciente> GetPacientesPorFiltro(string filtro)
        {
            var pacientes=GetAllPacientes();
            if (pacientes != null)  
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    pacientes = pacientes.Where(s => s.Pacientes.Contains(filtro)); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return pacientes;
            //return _appContext.Pacientes;
        }*/
        public Paciente UpdatePaciente(Paciente paciente)
        {
            // Buscar usuario a actualizar

            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(u => u.Id == paciente.Id);
            if (pacienteEncontrado != null)
            {
                pacienteEncontrado.Nombre=paciente.Nombre;
                pacienteEncontrado.Apellidos=paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono=paciente.NumeroTelefono;
                pacienteEncontrado.Genero=paciente.Genero;
                pacienteEncontrado.Direccion=paciente.Direccion;
                

                _appContext.SaveChanges();
            }

            return pacienteEncontrado;
        }
    }
}