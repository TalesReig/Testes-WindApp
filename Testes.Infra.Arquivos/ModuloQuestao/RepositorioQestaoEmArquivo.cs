using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.ModuloQuestao;
using Testes.Infra.Arquivos.Compartilhado;

namespace Testes.Infra.Arquivos.ModuloQuestao
{
    public class RepositorioQestaoEmArquivo : RepositorioBaseEmArquivo<Questao>
    {
        public RepositorioQestaoEmArquivo(DataContext dataContext) : base(dataContext)
        {
        }

        public override List<Questao> ObterRegistros()
        {
            return dataContext.Questao;
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();
        }
    }
}

