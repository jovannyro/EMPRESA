using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface I_RepositorioEmpresa
    {
        IEnumerable<Empresa> GetAllEmpresa();
        Empresa AddEmpresa(Empresa empresa);
        Empresa UpdateEmpresa(Empresa empresa);
        void DeleteEmpresa(int IdEmpresa);
        Empresa GetEmpresa(int IdEmpresa);
    }
}