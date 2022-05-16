using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.Compartilhado;
using Testes.Dominio.ModuloMatérias;

namespace Testes.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public Materia materia { get; set; }

        public DisciplinaEnum disciplina { get; set; }
        public string titulo { get; set; }
        public string enunciado { get; set; }
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
        public string d { get; set; }
        public string gabarito { get; set; }

        public override void Atualizar(Questao registro)
        {
            this.materia = registro.materia;
            this.enunciado = registro.enunciado;
            this.a = registro.a;
            this.b = registro.b;
            this.c = registro.c;
            this.d = registro.d;
            this.gabarito = registro.gabarito;

        }
    }
}
