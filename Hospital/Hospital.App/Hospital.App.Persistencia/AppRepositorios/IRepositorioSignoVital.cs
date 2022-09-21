using System;
using Hospital.App.Dominio;

namespace Hospital.App.Persistencia
{
    public interface IRepositorioSignoVital
    {
        IEnumerable <SignoVital> GetAllSignosVitales();
        
        SignoVital AddSignoVital (SignoVital signoVital);

        SignoVital UpdateSignoVital (SignoVital signoVital);

        public void DeleteSignoVital (int idSignoVital);

        public SignoVital GetSignoVital (int idSignoVital);
    }
}