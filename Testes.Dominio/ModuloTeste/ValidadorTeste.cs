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
            RuleFor(x => x.titulo).NotNull().NotEmpty();

            RuleFor(x => x.qntQuestoes).NotNull().NotEmpty();

            RuleFor(x => x.turma).NotNull().NotEmpty();

            RuleFor(x => x.disciplinaEnum).NotNull().NotEmpty();

            RuleFor(x => x.materia).NotNull().NotEmpty();
        }
    }
}
