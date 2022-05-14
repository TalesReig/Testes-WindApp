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
        public List<Materia> Materia { get; set; }

        public List<Questao> Questao { get; set; }

        public List<Teste> Teste { get; set; }

        public DataContext()
        {
            Materia = new List<Materia>();

            Questao = new List<Questao>();

            Teste = new List<Teste>();
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

            if (ctx.Materia.Any())
                this.Materia.AddRange(ctx.Materia);

            if (ctx.Questao.Any())
                this.Questao.AddRange(ctx.Questao);

            if (ctx.Teste.Any())
                this.Teste.AddRange(ctx.Teste);
        }

    }
}
