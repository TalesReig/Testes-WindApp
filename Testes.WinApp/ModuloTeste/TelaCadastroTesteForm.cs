using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testes.Dominio.ModuloTeste;

namespace Testes.WinApp.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        public Teste teste;
        public TelaCadastroTesteForm()
        {
            InitializeComponent();
        }

        public Func<Teste, ValidationResult> GravarRegistro { get; set; }

        public Teste Teste
        {
            get
            {
                return teste;
            }
            set
            {
                teste = value;
                txtTitulo.Text = teste.titulo;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            teste.titulo = txtTitulo.Text;

            var resultadoValidacao = GravarRegistro(teste);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                //TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            teste.titulo = txtTitulo.Text;

            var resultadoValidacao = GravarRegistro(teste);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                //TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
