using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testes.Dominio.ModuloMatérias;
using Testes.Dominio.ModuloQuestao;
using Testes.Infra.Arquivos.ModuloMatérias;
using Testes.Infra.Arquivos.ModuloQuestao;
using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloQuestões
{
    public class ControladorQuestao : ControladorBase
    {
        private RepositorioMateriaEmArquivo repositorioMateria;
        private RepositorioQestaoEmArquivo repositorioQestao;
        private TabelaQuestaoControl tabelaQuestaos;

        public ControladorQuestao(RepositorioQestaoEmArquivo repositorioQestao, RepositorioMateriaEmArquivo repositorioMateria)
        {
            this.repositorioQestao = repositorioQestao;
            this.repositorioMateria = repositorioMateria;
        }

        public override void Inserir()
        {
            List<Materia> Materias = repositorioMateria.SelecionarTodos();
            TelaCadastroQuestaoForm tela = new TelaCadastroQuestaoForm(Materias);
            tela.Questao = new Questao();

            tela.GravarRegistro = repositorioQestao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarQuestao();
            }
        }

        public override void Editar()
        {
            Questao QuestaoSelecionada = ObtemQuestaoSelecionada();

            if (QuestaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Edição de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<Materia> Materias = repositorioMateria.SelecionarTodos();
            TelaCadastroQuestaoForm tela = new TelaCadastroQuestaoForm(Materias);

            tela.Questao = QuestaoSelecionada;

            tela.GravarRegistro = repositorioQestao.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarQuestao();
            }
        }

        public override void Excluir()
        {
            Questao tarefaSelecionada = ObtemQuestaoSelecionada();

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma Questao primeiro",
                "Exclusão de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a tarefa?",
                "Exclusão de Tarefas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioQestao.Excluir(tarefaSelecionada);
                CarregarQuestao();
            }
        }

        private void CarregarQuestao()
        {
            List<Questao> Questaos = repositorioQestao.SelecionarTodos();

            tabelaQuestaos.AtualizarRegistros(Questaos);
            //TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {tarefas.Count} tarefa(s) {tipoTarefa}");
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaQuestaos == null)
                tabelaQuestaos = new TabelaQuestaoControl();

            CarregarQuestao();

            return tabelaQuestaos;
        }

        private Questao ObtemQuestaoSelecionada()
        {
            var numero = tabelaQuestaos.ObtemNumeroQuestaoSelecionado();

            return repositorioQestao.SelecionarPorNumero(numero);
        }

    }
}
