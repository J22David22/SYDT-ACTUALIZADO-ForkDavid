using System;
using Hospital.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Persistencia
{
    public class RepositorioAuxiliar : IRepositorioAuxiliar
    {
        //Conectar a la BDs

        private readonly AppContext _appContext;

        public RepositorioAuxiliar()
        {
            
        }
        public RepositorioAuxiliar (AppContext appContext)
        {
            this._appContext = appContext;
        }
        public Auxiliar AddAuxiliar(Auxiliar auxiliar)
        {
            // configuramos el ambiente para adicionar un usuario a la BD
            var auxiliarAdicionada = _appContext.Auxiliares.Add(auxiliar);
            // guardar la información en la BD
            _appContext.SaveChanges();

            return auxiliarAdicionada.Entity;
        }
        public void DeleteAuxiliar(int idAuxiliar)
        {
            var auxiliarAEliminar=_appContext.Auxiliares.FirstOrDefault(m => m.Id == idAuxiliar);

            /* select*from medico where u.Id = idmedico */

            if (auxiliarAEliminar !=null)
            {
                _appContext.Auxiliares.Remove(auxiliarAEliminar);
                _appContext.SaveChanges();
            }
        }
        public Auxiliar GetAuxiliar (int idAuxiliar)
        {
           return _appContext.Auxiliares.FirstOrDefault( m => m.Id == idAuxiliar);
        }
        public IEnumerable<Auxiliar> GetAllAuxiliares()
        {
            return _appContext.Auxiliares;
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
        public Auxiliar UpdateAuxiliar(Auxiliar auxiliar)
        {
            // Buscar usuario a actualizar

            var auxiliarEncontrado = _appContext.Auxiliares.FirstOrDefault(u => u.Id == auxiliar.Id);
            if (auxiliarEncontrado != null)
            {
                auxiliarEncontrado.Nombre=auxiliar.Nombre;
                auxiliarEncontrado.Apellidos=auxiliar.Apellidos;
                auxiliarEncontrado.NumeroTelefono=auxiliar.NumeroTelefono;
                auxiliarEncontrado.Genero=auxiliar.Genero;
                

                _appContext.SaveChanges();
            }

            return auxiliarEncontrado;
        }
    }
}