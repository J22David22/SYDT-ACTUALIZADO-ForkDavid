using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioPersona
    {
        IEnumerable <Persona> GetAllPersonas();
        
        Persona AddPersona (Persona persona);

        Persona UpdatePersona(Persona persona);

        public void DeletePersona (int idPersona);

        public Persona GetPersona(int idPersona);
    }
}