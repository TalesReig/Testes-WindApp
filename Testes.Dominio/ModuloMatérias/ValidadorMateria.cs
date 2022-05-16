using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes.Dominio.ModuloMatérias
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.nome).NotNull().NotEmpty();

            RuleFor(x => x.disciplina).NotNull().NotEmpty();

            RuleFor(x => x.turma).NotNull().NotEmpty();
        }
    }
}
