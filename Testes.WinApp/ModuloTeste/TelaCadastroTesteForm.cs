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
using Testes.Dominio.ModuloTeste;

namespace Testes.WinApp.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        //public RepositorioQuestao repositorioQuestao;
        public List<Materia> Materias;
        public Teste teste;

        public TelaCadastroTesteForm(List<Materia> materias)
        {
            Materias = materias;
            InitializeComponent();
            CarregarDisciplinas();
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
                txtQuestoes.Text = teste.Numero.ToString();
                if(teste.turma == "Primeira Série")
                {
                    btn1.Checked = true;
                }
                else
                {
                    btn2.Checked = false;
                }
                cbxDisciplina.SelectedItem = teste.disciplinaEnum;
                cbxMateria.SelectedItem = teste.materia;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            teste.titulo = txtTitulo.Text;
            int n = Convert.ToInt32(txtQuestoes.Text);
            teste.qntQuestoes = n;
            if (btn1.Checked)
            {
                teste.turma = "Primeira Série";
            }
            else
            {
                teste.turma = "Segunda Série";
            }
            teste.disciplinaEnum = (DisciplinaEnum)cbxDisciplina.SelectedItem;
            teste.materia = (Materia)cbxMateria.SelectedItem;

            var resultadoValidacao = GravarRegistro(teste);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void CarregarDisciplinas()
        {
            cbxDisciplina.Items.Clear();
            foreach (int i in Enum.GetValues(typeof(DisciplinaEnum)))
            {
                cbxDisciplina.Items.Add((DisciplinaEnum)i);
            }
        }

        private void cbxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplinaEnum disciplina = (DisciplinaEnum)cbxDisciplina.SelectedItem;
            CarregarMaterias(Materias, disciplina);
        }

        private void CarregarMaterias(List<Materia> Materias, DisciplinaEnum disciplina)
        {
            cbxMateria.Items.Clear();
            cbxMateria.Text = "";

            foreach (Materia materia in Materias)
            {
                if (materia.disciplina == disciplina)
                {
                    cbxMateria.Items.Add(materia);
                }
            }
        }
    }
}
