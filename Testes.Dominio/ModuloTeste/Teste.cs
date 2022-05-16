using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.Compartilhado;
using Testes.Dominio.ModuloMatérias;
using Testes.Dominio.ModuloQuestao;

namespace Testes.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string titulo { get; set; }
        public int qntQuestoes { get; set; }
        public string turma { get; set; }
        public DisciplinaEnum disciplinaEnum { get; set; }
        public Materia materia { get; set; }
        //public DateTime data { get; set; }

        public List<Questao> questaos;

        public override void Atualizar(Teste registro)
        {
            this.titulo = registro.titulo;
            //data = DateTime.Now;
        }
    }
}
