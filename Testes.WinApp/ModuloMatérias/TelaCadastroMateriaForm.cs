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
using Testes.Dominio.ModuloMatérias;

namespace Testes.WinApp.ModuloMatérias
{
    public partial class TelaCadastroMateriaForm : Form
    {
        public Materia materia;
        public TelaCadastroMateriaForm()
        {
            InitializeComponent();
        }

        public Func<Materia, ValidationResult> GravarRegistro { get; set; }

        public Materia Materia
        {
            get
            {
                return materia;
            }
            set
            {
                materia = value;
                txt_Nome.Text = materia.nome;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            materia.nome = txt_Nome.Text;

            var resultadoValidacao = GravarRegistro(materia);

            if(resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                //TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
