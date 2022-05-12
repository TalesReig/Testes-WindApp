using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.Compartilhado;
using Testes.Dominio.ModuloQuestao;

namespace Testes.Dominio.ModuloMatérias
{
    public class Materia : EntidadeBase<Materia>
    {
        public string nome { get; set; }
        public DisciplinaEnum disciplina { get; set; }
        public List<Questao> questoes { get; set; }
        public string turma { get; set; }

        public Materia()
        {
        }

        public override void Atualizar(Materia registro)
        {
            this.nome = registro.nome;
        }
        
    }
}
