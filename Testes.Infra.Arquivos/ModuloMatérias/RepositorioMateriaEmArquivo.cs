

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.ModuloMatérias;
using Testes.Infra.Arquivos.Compartilhado;

namespace Testes.Infra.Arquivos.ModuloMatérias
{
    public class RepositorioMateriaEmArquivo : RepositorioBaseEmArquivo<Materia>
    {
        public RepositorioMateriaEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if(dataContext.Materias != null && dataContext.Materias.Count > 0)
            {
                this.contador = dataContext.Materias.Max(x => x.Numero);
            }

        }

        public override List<Materia> ObterRegistros()
        {
            return dataContext.Materias;
        }

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();
        }
    }
}
