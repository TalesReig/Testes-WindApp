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
using Testes.Infra.Arquivos.ModuloTeste;
using Testes.WinApp.Compartilhado;
using Testes.WinApp.ModuloMatérias;
using Testes.WinApp.ModuloQuestões;
using Testes.WinApp.ModuloTeste;

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
            Instancia = this;
            labelRodape.Text = string.Empty;
            //labelTipoCadastro.Text = string.Empty;
            ConfiguracaoToolStripTelaInicial();
            this.contextoDados = contextoDados;
            InicializarControladores();
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void questõesMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoToolStripQuestoes();
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void matériasMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoToolStripMateria();
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void provasMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoToolStripTestes();
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
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

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            controlador.Duplicar();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            controlador.GerarPDF();
        }

        #region métodos privados

        private void ConfiguracaoToolStripQuestoes()
        {
            btnCadastrar.Visible = true;
            btnEditar.Visible = true;
            btnExcluir.Visible = true;
            btnPDF.Visible = false;
            btnDuplicar.Visible = false;
            btnCadastrar.ToolTipText = "Cadastrar Questão";
            btnEditar.ToolTipText = "Editar Questão";
            btnExcluir.ToolTipText = "Excluir Questão";
        }

        private void ConfiguracaoToolStripMateria()
        {
            btnCadastrar.Visible = true;
            btnEditar.Visible = true;
            btnExcluir.Visible = true;
            btnPDF.Visible = false;
            btnDuplicar.Visible = false;
            btnCadastrar.ToolTipText = "Cadastrar Materia";
            btnEditar.ToolTipText = "Editar Materia";
            btnExcluir.ToolTipText = "Excluir Materia";
        }

        private void ConfiguracaoToolStripTestes()
        {
            btnCadastrar.Visible = true;
            btnEditar.Visible = true;
            btnExcluir.Visible = true;
            btnPDF.Visible = true;
            btnDuplicar.Visible = true;
            btnCadastrar.ToolTipText = "Cadastrar Teste";
            btnEditar.ToolTipText = "Editar Teste";
            btnExcluir.ToolTipText = "Excluir Teste";
        }

        private void ConfiguracaoToolStripTelaInicial()
        {
            btnCadastrar.Visible = false;
            btnEditar.Visible = false;
            btnExcluir.Visible = false;
            btnDuplicar.Visible = false;
            btnPDF.Visible = false;
        }

        private void InicializarControladores()
        {
            var repositorioMateria = new RepositorioMateriaEmArquivo(contextoDados);
            var repositorioQuestao = new RepositorioQestaoEmArquivo(contextoDados);
            var repositorioTeste = new RepositorioTesteEmArquivo(contextoDados);

            controladores = new Dictionary<string, ControladorBase>();
            
            controladores.Add("Matérias", new ControladorMateria(repositorioMateria));
            controladores.Add("Questões", new ControladorQuestao(repositorioQuestao,repositorioMateria));
            controladores.Add("Provas", new ControladorTeste(repositorioTeste, repositorioMateria, repositorioQuestao));
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            PainelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            PainelRegistros.Controls.Add(listagemControl);
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarListagem();
        }
        #endregion

        
    }
}
