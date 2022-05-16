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
            PreencheTela();
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
                cbx_Disciplinas.SelectedItem = materia.disciplina;
                cbx_Turma.SelectedItem = materia.turma;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            materia.nome = txt_Nome.Text;
            materia.disciplina = (DisciplinaEnum)cbx_Disciplinas.SelectedItem;
            materia.turma = (SerieEnum)cbx_Turma.SelectedItem;

            var resultadoValidacao = GravarRegistro(materia);

            if(resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        public void PreencheTela()
        {
            cbx_Disciplinas.Items.Clear();
            foreach (int i in Enum.GetValues(typeof(DisciplinaEnum))){
                cbx_Disciplinas.Items.Add((DisciplinaEnum)i);
            }

            cbx_Turma.Items.Clear();
            foreach (int i in Enum.GetValues(typeof(SerieEnum)))
            {
                cbx_Turma.Items.Add((SerieEnum)i);
            }
        }

    }
}
