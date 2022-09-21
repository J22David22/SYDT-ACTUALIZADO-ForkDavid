using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioEnfermera
    {
        IEnumerable <Enfermera> GetAllEnfermeras();
        //IEnumerable<Enfermera> GetEnfermerasPorFiltro(string filtro);
        
        Enfermera AddEnfermera (Enfermera enfermera);

        Enfermera UpdateEnfermera(Enfermera enfermera);

        public void DeleteEnfermera (int idEnfermera);

        public Enfermera GetEnfermera(int idEnfermera);
    }
}