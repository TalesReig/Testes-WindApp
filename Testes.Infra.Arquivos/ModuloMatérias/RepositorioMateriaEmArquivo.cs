

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
        }

        public override List<Materia> ObterRegistros()
        {
            return dataContext.Materia;
        }

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();
        }
    }
}
