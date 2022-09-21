using System;
using Hospital.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Persistencia
{
    public class RepositorioPersona : IRepositorioPersona
    {
        //Conectar a la BDs

        private readonly AppContext _appContext;

        public RepositorioPersona()
        {
            
        }
        public RepositorioPersona (AppContext appContext)
        {
            this._appContext = appContext;
        }
        public Persona AddPersona(Persona persona)
        {
            // configuramos el ambiente para adicionar un usuario a la BD
            var personaAdicionada = _appContext.Personas.Add(persona);
            // guardar la información en la BD
            _appContext.SaveChanges();

            return personaAdicionada.Entity;
        }
        public void DeletePersona(int idPersona)
        {
            var personaAEliminar=_appContext.Personas.FirstOrDefault(m => m.Id == idPersona);

            /* select*from medico where u.Id = idmedico */

            if (personaAEliminar !=null)
            {
                _appContext.Personas.Remove(personaAEliminar);
                _appContext.SaveChanges();
            }
        }
        public Persona GetPersona (int idPersona)
        {
           return _appContext.Personas.FirstOrDefault( m => m.Id == idPersona);
        }
        public IEnumerable<Persona> GetAllPersonas()
        {
            return _appContext.Personas;
        }
        public Persona UpdatePersona(Persona persona)
        {
            // Buscar usuario a actualizar

            var personaEncontrado = _appContext.Personas.FirstOrDefault(u => u.Id == persona.Id);
            if (personaEncontrado != null)
            {
                personaEncontrado.Nombre=persona.Nombre;
                personaEncontrado.Apellidos=persona.Apellidos;
                personaEncontrado.NumeroTelefono=persona.NumeroTelefono;
                personaEncontrado.Genero=persona.Genero;
                

                _appContext.SaveChanges();
            }

            return personaEncontrado;
        }
    }
}