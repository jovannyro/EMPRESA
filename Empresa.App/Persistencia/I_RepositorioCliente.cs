using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface I_RepositorioCliente
    {
        IEnumerable<Cliente> GetAllCliente();
        Cliente AddCliente(Cliente cliente);
        Cliente UpdateCliente(Cliente cliente);
        void DeleteCliente(int IdCliente);
        Cliente GetCliente(int IdCliente);
        Cliente EsCliente(int IdCliente, int IdEmpresa);
    }
}