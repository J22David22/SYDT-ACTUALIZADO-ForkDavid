using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioAuxiliar
    {
        IEnumerable <Auxiliar> GetAllAuxiliares();
        //IEnumerable<Auxiliar> GetAuxiliarsPorFiltro(string filtro);
        
        Auxiliar AddAuxiliar (Auxiliar auxiliar);

        Auxiliar UpdateAuxiliar(Auxiliar auxiliar);

        public void DeleteAuxiliar (int idAuxiliar);

        public Auxiliar GetAuxiliar(int idAuxiliar);
    }
}