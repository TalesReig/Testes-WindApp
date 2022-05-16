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
            if (dataContext.Quetoes != null && dataContext.Quetoes.Count > 0)
            {
                this.contador = dataContext.Quetoes.Max(x => x.Numero);
            }
        }

        public override List<Questao> ObterRegistros()
        {
            return dataContext.Quetoes;
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();
        }
    }
}

