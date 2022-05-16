using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Infra.Arquivos.Compartilhado.Serializadores;
using Testes.Dominio.ModuloMatérias;
using Testes.Dominio.ModuloQuestao;
using Testes.Dominio.ModuloTeste;

namespace Testes.Infra.Arquivos.Compartilhado
{
    [Serializable]
    public class DataContext
    {
        private readonly ISerializador serializador;
        public List<Materia> Materias { get; set; }

        public List<Questao> Quetoes { get; set; }

        public List<Teste> Testes { get; set; }

        public DataContext()
        {
            Materias = new List<Materia>();

            Quetoes = new List<Questao>();

            Testes = new List<Teste>();
        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Materias.Any())
                this.Materias.AddRange(ctx.Materias);

            if (ctx.Quetoes.Any())
                this.Quetoes.AddRange(ctx.Quetoes);

            if (ctx.Testes.Any())
                this.Testes.AddRange(ctx.Testes);
        }

    }
}
