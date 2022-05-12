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
using Testes.Dominio.ModuloQuestao;

namespace Testes.WinApp.ModuloQuestões
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        public Questao questao;
        public TelaCadastroQuestaoForm()
        {
            InitializeComponent();
        }
        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        public Questao Questao
        {
            get
            {
                return questao;
            }
            set
            {
                questao = value;
                txtTitulo.Text = questao.titulo;
            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            questao.titulo = txtTitulo.Text;

            var resultadoValidacao = GravarRegistro(questao);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                //TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
