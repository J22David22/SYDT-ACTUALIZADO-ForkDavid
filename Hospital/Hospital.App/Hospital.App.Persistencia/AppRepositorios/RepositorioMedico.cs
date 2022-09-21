using System;
using Hospital.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
    {
        //Conectar a la BDs

        private readonly AppContext _appContext;

        public RepositorioMedico()
        {
            
        }
        public RepositorioMedico (AppContext appContext)
        {
            this._appContext = appContext;
        }
        public Medico AddMedico(Medico medico)
        {
            // configuramos el ambiente para adicionar un usuario a la BD
            var medicoAdicionado = _appContext.Medicos.Add(medico);
            // guardar la información en la BD
            _appContext.SaveChanges();

            return medicoAdicionado.Entity;
        }
        public void DeleteMedico(int idMedico)
        {
            var medicoAEliminar=_appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);

            /* select*from medico where u.Id = idmedico */

            if (medicoAEliminar !=null)
            {
                _appContext.Medicos.Remove(medicoAEliminar);
                _appContext.SaveChanges();
            }
        }
        public Medico GetMedico (int idMedico)
        {
           return _appContext.Medicos.FirstOrDefault( m => m.Id == idMedico);
        }
        public IEnumerable<Medico> GetAllMedicos()
        {
            return _appContext.Medicos;
        }
        public Medico UpdateMedico(Medico medico)
        {
            // Buscar usuario a actualizar

            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(u => u.Id == medico.Id);
            if (medicoEncontrado != null)
            {
                medicoEncontrado.Nombre=medico.Nombre;
                medicoEncontrado.Apellidos=medico.Apellidos;
                medicoEncontrado.NumeroTelefono=medico.NumeroTelefono;
                medicoEncontrado.Genero=medico.Genero;
                medicoEncontrado.Especialidad=medico.Especialidad;
                medicoEncontrado.Codigo=medico.Codigo;
                medicoEncontrado.RegistroRethus=medico.RegistroRethus;

                _appContext.SaveChanges();
            }

            return medicoEncontrado;
        }
    }
}