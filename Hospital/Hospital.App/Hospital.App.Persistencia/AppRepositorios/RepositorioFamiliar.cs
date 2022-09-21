using System;
using Hospital.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Persistencia
{
    public class RepositorioFamiliar : IRepositorioFamiliar
    {
        //Conectar a la BDs

        private readonly AppContext _appContext;

        public RepositorioFamiliar()
        {
            
        }
        public RepositorioFamiliar (AppContext appContext)
        {
            this._appContext = appContext;
        }
        public Familiar AddFamiliar(Familiar familiar)
        {
            // configuramos el ambiente para adicionar un usuario a la BD
            var familiarAdicionada = _appContext.Familiares.Add(familiar);
            // guardar la información en la BD
            _appContext.SaveChanges();

            return familiarAdicionada.Entity;
        }
        public void DeleteFamiliar(int idFamiliar)
        {
            var familiarAEliminar=_appContext.Familiares.FirstOrDefault(m => m.Id == idFamiliar);

            /* select*from medico where u.Id = idmedico */

            if (familiarAEliminar !=null)
            {
                _appContext.Familiares.Remove(familiarAEliminar);
                _appContext.SaveChanges();
            }
        }
        public Familiar GetFamiliar (int idFamiliar)
        {
           return _appContext.Familiares.FirstOrDefault( m => m.Id == idFamiliar);
        }
        public IEnumerable<Familiar> GetAllFamiliares()
        {
            return _appContext.Familiares;
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
        public Familiar UpdateFamiliar(Familiar familiar)
        {
            // Buscar usuario a actualizar

            var familiarEncontrado = _appContext.Familiares.FirstOrDefault(u => u.Id == familiar.Id);
            if (familiarEncontrado != null)
            {
                familiarEncontrado.Nombre=familiar.Nombre;
                familiarEncontrado.Apellidos=familiar.Apellidos;
                familiarEncontrado.NumeroTelefono=familiar.NumeroTelefono;
                familiarEncontrado.Genero=familiar.Genero;
                familiarEncontrado.Parentesco=familiar.Parentesco;
                familiarEncontrado.Correo=familiar.Correo;
                familiarEncontrado.DireccionFamiliar=familiar.DireccionFamiliar;
                

                _appContext.SaveChanges();
            }

            return familiarEncontrado;
        }
    }
}