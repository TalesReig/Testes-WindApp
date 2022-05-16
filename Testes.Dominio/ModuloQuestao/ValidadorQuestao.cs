using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes.Dominio.ModuloQuestao
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(x => x.titulo).NotNull().NotEmpty();

            RuleFor(x => x.disciplina).NotNull().NotEmpty();

            RuleFor(x => x.materia).NotNull().NotEmpty();

            RuleFor(x => x.enunciado).NotNull().NotEmpty();

            RuleFor(x => x.a).NotNull().NotEmpty().NotEqual(x => x.b).NotEqual(x => x.c).NotEqual(x => x.d);

            RuleFor(x => x.b).NotNull().NotEmpty().NotEqual(x => x.a).NotEqual(x => x.c).NotEqual(x => x.d);

            RuleFor(x => x.c).NotNull().NotEmpty().NotEqual(x => x.a).NotEqual(x => x.b).NotEqual(x => x.d);

            RuleFor(x => x.d).NotNull().NotEmpty().NotEqual(x => x.a).NotEqual(x => x.b).NotEqual(x => x.c);
        }
    }
}
