using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioMedico
    {
        IEnumerable <Medico> GetAllMedicos();
        
        Medico AddMedico (Medico medico);

        Medico UpdateMedico(Medico medico);

        public void DeleteMedico (int idMedico);

        public Medico GetMedico(int idMedico);
    }
}