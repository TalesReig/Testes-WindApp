using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Results;
using Testes.Dominio.ModuloTeste;
using Testes.Infra.Arquivos.Compartilhado;

namespace Testes.Infra.Arquivos.ModuloTeste
{
    public class RepositorioTesteEmArquivo : RepositorioBaseEmArquivo<Teste>
    {
        public RepositorioTesteEmArquivo(DataContext dataContext) : base(dataContext)
        {
        }

        public ValidationResult Duplicar(Teste registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                var registros = ObterRegistros();
                registros.Add(registro);
            }

            return resultadoValidacao;

        }

        public override List<Teste> ObterRegistros()
        {
            return dataContext.Teste;
        }

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorTeste();
        }
    }
}
