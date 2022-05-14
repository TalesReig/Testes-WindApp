using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testes.Dominio.ModuloTeste;
using Testes.Infra.Arquivos.ModuloTeste;
using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloTeste
{
    internal class ControladorTeste : ControladorBase
    {
        private RepositorioTesteEmArquivo repositorioTeste;
        private TabelaTesteControl tabelaTestes;


        public ControladorTeste(RepositorioTesteEmArquivo repositorioTeste)
        {
            this.repositorioTeste = repositorioTeste;
        }

        public override void Inserir()
        {
            TelaCadastroTesteForm tela = new TelaCadastroTesteForm();
            tela.Teste = new Teste();

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTeste();
            }
        }

        public override void Editar()
        {
            Teste TesteSelecionada = ObtemTesteSelecionada();

            if (TesteSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Edição de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm();

            tela.Teste = TesteSelecionada;

            tela.GravarRegistro = repositorioTeste.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTeste();
            }
        }

        public override void Excluir()
        {
            Teste tarefaSelecionada = ObtemTesteSelecionada();

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma Teste primeiro",
                "Exclusão de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a tarefa?",
                "Exclusão de Tarefas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(tarefaSelecionada);
                CarregarTeste();
            }
        }

        public override void Duplicar()
        {
            Teste TesteSelecionada = ObtemTesteSelecionada();

            if (TesteSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Edição de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            repositorioTeste.Inserir(TesteSelecionada);

            CarregarTeste();
        }

        private void CarregarTeste()
        {
            List<Teste> Testes = repositorioTeste.SelecionarTodos();

            tabelaTestes.AtualizarRegistros(Testes);
            //TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {tarefas.Count} tarefa(s) {tipoTarefa}");
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTestes == null)
                tabelaTestes = new TabelaTesteControl();

            CarregarTeste();

            return tabelaTestes;
        }

        private Teste ObtemTesteSelecionada()
        {
            int numero = (int)tabelaTestes.ObtemNumeroTesteSelecionado();

            return repositorioTeste.SelecionarPorNumero(numero);
        }
    }
}
