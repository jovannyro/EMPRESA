using System.Collections.Generic;
using System.Linq;
using Dominio;

//Falta llevar al Main()

namespace Persistencia
{
    public class RepositorioCliente : I_RepositorioCliente

    {
        private readonly AppContext _appContext;
        public RepositorioCliente(AppContext appContext)
        {
            _appContext = appContext;
        }

        Cliente I_RepositorioCliente.AddCliente(Cliente cliente)
        {
            var ClienteAdicionado = _appContext.Clientes.Add(cliente);
            _appContext.SaveChanges();
            return ClienteAdicionado.Entity;
        }

        void I_RepositorioCliente.DeleteCliente(int IdCliente)
        {
            var ClienteEncontrado = _appContext.Clientes.FirstOrDefault(cli => cli.Id == IdCliente);
            if (ClienteEncontrado == null)
                return;
            _appContext.Clientes.Remove(ClienteEncontrado);
            _appContext.SaveChanges();
        }

        Cliente I_RepositorioCliente.EsCliente(int IdCliente, int IdEmpresa)
        {
            var ClienteEncontrado = _appContext.Clientes.FirstOrDefault(cli => cli.Id == IdCliente);
            if (ClienteEncontrado != null)
            {
                var empresaEncontrada = _appContext.Empresas.FirstOrDefault(em => em.Id == IdEmpresa);
                if (empresaEncontrada != null)
                {
                    ClienteEncontrado.EsCliente = empresaEncontrada;
                    _appContext.SaveChanges();
                }
                return ClienteEncontrado;
            }
            return null;
        }

        IEnumerable<Cliente> I_RepositorioCliente.GetAllCliente()
        {
            return _appContext.Clientes;
        }

        Cliente I_RepositorioCliente.GetCliente(int IdCliente)
        {
            return _appContext.Clientes.FirstOrDefault(cli => cli.Id == IdCliente);
        }

        Cliente I_RepositorioCliente.UpdateCliente(Cliente cliente)
        {
            var ClienteEncontrado = _appContext.Clientes.FirstOrDefault(cli => cli.Id == cliente.Id);
            if (ClienteEncontrado == null)
            {
                ClienteEncontrado.Telefono = cliente.Telefono;
                ClienteEncontrado.EsCliente = cliente.EsCliente;
                
                _appContext.SaveChanges();
            }               
            return ClienteEncontrado;
        }
    }
}