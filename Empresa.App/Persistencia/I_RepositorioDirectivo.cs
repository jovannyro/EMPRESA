using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface I_RepositorioDirectivo
    {
        IEnumerable<Directivo> GetAllDirectivo();
        Directivo AddDirectivo(Directivo directivo);
        Directivo UpdateDirectivo(Directivo directivo);
        void DeleteDirectivo(int IdDirectivo);
        Directivo GetDirectivo(int IdDirectivo);
        Directivo Subordinado(int IdDirectivo, int IdEmpleado);
    }
}