using System;
using Hospital.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Persistencia
{
    public class RepositorioEnfermera : IRepositorioEnfermera
    {
        //Conectar a la BDs

        private readonly AppContext _appContext;

        public RepositorioEnfermera()
        {
            
        }
        public RepositorioEnfermera (AppContext appContext)
        {
            this._appContext = appContext;
        }
        public Enfermera AddEnfermera(Enfermera enfermera)
        {
            // configuramos el ambiente para adicionar un usuario a la BD
            var enfermeraAdicionada = _appContext.Enfermeras.Add(enfermera);
            // guardar la información en la BD
            _appContext.SaveChanges();

            return enfermeraAdicionada.Entity;
        }
        public void DeleteEnfermera(int idEnfermera)
        {
            var enfermeraAEliminar=_appContext.Enfermeras.FirstOrDefault(m => m.Id == idEnfermera);

            /* select*from medico where u.Id = idmedico */

            if (enfermeraAEliminar !=null)
            {
                _appContext.Enfermeras.Remove(enfermeraAEliminar);
                _appContext.SaveChanges();
            }
        }
        public Enfermera GetEnfermera (int idEnfermera)
        {
           return _appContext.Enfermeras.FirstOrDefault( m => m.Id == idEnfermera);
        }
        public IEnumerable<Enfermera> GetAllEnfermeras()
        {
            return _appContext.Enfermeras;
        }

        /*public IEnumerable<Enfermera> GetEnfermerasPorFiltro(string filtro)
        {
            var enfermeras=GetAllenfermeras();
            if (enfermeras != null)  
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    enfermeras = enfermeras.Where(s => s.enfermeras.Contains(filtro)); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return enfermeras;
            //return _appContext.enfermeras;
        }*/
        public Enfermera UpdateEnfermera(Enfermera enfermera)
        {
            // Buscar usuario a actualizar

            var enfermeraEncontrado = _appContext.Enfermeras.FirstOrDefault(u => u.Id == enfermera.Id);
            if (enfermeraEncontrado != null)
            {
                enfermeraEncontrado.Nombre=enfermera.Nombre;
                enfermeraEncontrado.Apellidos=enfermera.Apellidos;
                enfermeraEncontrado.NumeroTelefono=enfermera.NumeroTelefono;
                enfermeraEncontrado.Genero=enfermera.Genero;
                

                _appContext.SaveChanges();
            }

            return enfermeraEncontrado;
        }
    }
}