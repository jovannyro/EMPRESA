using System.Collections.Generic;
using System.Linq;
using Dominio;

//Falta llevar al Main()

namespace Persistencia
{
    public class RepositorioEmpresa : I_RepositorioEmpresa
    {
        private readonly AppContext _appContext;
        public RepositorioEmpresa(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        public Empresa AddEmpresa(Empresa empresa)
        {
            var EmpresaAdicionada = _appContext.Empresas.Add(empresa);
            _appContext.SaveChanges();
            return EmpresaAdicionada.Entity;
        }

        public void DeleteEmpresa(int IdEmpresa)
        {
            var EmpresaEncontrada = _appContext.Empresas.FirstOrDefault(em => em.Id == IdEmpresa);
            if (EmpresaEncontrada == null)
                return;
            _appContext.Empresas.Remove(EmpresaEncontrada);
            _appContext.SaveChanges();
        }

        public IEnumerable<Empresa> GetAllEmpresa()
        {
            return _appContext.Empresas;
        }

        public Empresa GetEmpresa(int IdEmpresa)
        {
            return _appContext.Empresas.FirstOrDefault(em => em.Id == IdEmpresa);
        }

        public Empresa UpdateEmpresa(Empresa empresa)
        {
            var EmpresaEncontrada = _appContext.Empresas.FirstOrDefault(em => em.Id == empresa.Id);
            if (EmpresaEncontrada != null)
            {
                EmpresaEncontrada.Nombre = empresa.Nombre;
                EmpresaEncontrada.CIF = empresa.CIF;
                _appContext.SaveChanges();
            }
            return EmpresaEncontrada;
        }
    }
}