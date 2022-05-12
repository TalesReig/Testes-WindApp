using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testes.Dominio.ModuloMatérias;
using Testes.Infra.Arquivos.Compartilhado;
using Testes.Infra.Arquivos.ModuloMatérias;
using Testes.Infra.Arquivos.ModuloQuestao;
using Testes.WinApp.Compartilhado;
using Testes.WinApp.ModuloMatérias;
using Testes.WinApp.ModuloQuestões;

namespace Testes.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        private DataContext contextoDados;

        public TelaPrincipalForm(DataContext contextoDados)
        {
            InitializeComponent();

            this.contextoDados = contextoDados;
            InicializarControladores();
        }

        private void questõesMenuItem_Click(object sender, EventArgs e)
        {
            //TabelaQuestaoControl listagem = new TabelaQuestaoControl();
            //ConfiguracaoToolStripQuestoes();
            //listagem.Dock = DockStyle.Fill;
            //PainelRegistros.Controls.Clear();
            //PainelRegistros.Controls.Add(listagem);
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void matériasMenuItem_Click(object sender, EventArgs e)
        {
            //TabelaMateriasControl listagem = new TabelaMateriasControl();
            //PainelRegistros.Controls.Clear();
            //PainelRegistros.Controls.Add(listagem);
            //ConfiguracaoToolStripDisciplina();
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            //controlador = controladores["Matérias"];
        }

        private void provasMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoToolStripTestes();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {

        }

        #region métodos privados

        private void ConfiguracaoToolStripQuestoes()
        {
            btnPDF.Visible = false;
            btnCadastrar.ToolTipText = "Cadastrar Questão";
            btnEditar.ToolTipText = "Editar Questão";
            btnExcluir.ToolTipText = "Excluir Questão";
        }

        private void ConfiguracaoToolStripDisciplina()
        {
            btnPDF.Visible = false;
            btnCadastrar.ToolTipText = "Cadastrar Disciplina";
            btnEditar.ToolTipText = "Editar Disciplina";
            btnExcluir.ToolTipText = "Excluir Disciplina";
        }

        private void ConfiguracaoToolStripTestes()
        {
            btnPDF.Visible = true;
            btnCadastrar.ToolTipText = "Cadastrar Teste";
            btnEditar.ToolTipText = "Editar Teste";
            btnExcluir.ToolTipText = "Excluir Teste";
        }

        private void InicializarControladores()
        {
            var repositorioMateria = new RepositorioMateriaEmArquivo(contextoDados);
            var repositorioQuestao = new RepositorioQestaoEmArquivo(contextoDados);
            //var repositorioTeste = new RepositorioTesteEmArquivo(contextoDados);

            controladores = new Dictionary<string, ControladorBase>();
            
            controladores.Add("Matérias", new ControladorMateria(repositorioMateria));
            controladores.Add("Questões", new ControladorQuestao(repositorioQuestao));
            //controladores.Add("Teste", new ControladorCompromisso(repositorioCompromisso, repositorioContato));
        }

        private void ConfigurarListagem()
        {
            //AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            PainelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            PainelRegistros.Controls.Add(listagemControl);
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            //ConfigurarToolbox();

            ConfigurarListagem();
        }
        #endregion

    }
}
