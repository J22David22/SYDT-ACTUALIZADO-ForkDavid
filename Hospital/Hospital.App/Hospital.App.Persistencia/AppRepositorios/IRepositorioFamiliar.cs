using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioFamiliar
    {
        IEnumerable <Familiar> GetAllFamiliares();
        //IEnumerable<Familiar> GetFamiliarsPorFiltro(string filtro);
        
        Familiar AddFamiliar (Familiar familiar);

        Familiar UpdateFamiliar(Familiar familiar);

        public void DeleteFamiliar (int idFamiliar);

        public Familiar GetFamiliar(int idFamiliar);
    }
}