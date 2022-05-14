using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Testes.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            //implementar o resto das condições de crud;

            RuleFor(x => x.titulo).NotNull().NotEmpty();
        }
    }
}
