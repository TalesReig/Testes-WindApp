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
            if (dataContext.Testes != null && dataContext.Testes.Count > 0)
            {
                this.contador = dataContext.Testes.Max(x => x.Numero);
            }
        }

        public ValidationResult Duplicar(Teste novoRegistro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(novoRegistro);

            if (resultadoValidacao.IsValid)
            {
                novoRegistro.Numero = ++contador;

                var registros = ObterRegistros();

                registros.Add(novoRegistro);
            }

            return resultadoValidacao;

        }

        public override List<Teste> ObterRegistros()
        {
            return dataContext.Testes;
        }

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorTeste();
        }
    }
}
