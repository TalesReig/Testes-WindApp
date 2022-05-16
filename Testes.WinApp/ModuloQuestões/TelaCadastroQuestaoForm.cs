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
using Testes.Dominio.ModuloQuestao;

namespace Testes.WinApp.ModuloQuestões
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        public string[] alternativas = new string[] { "a", "b", "c", "d" };
        public List<Materia> Materias;
        public Questao questao;
        public TelaCadastroQuestaoForm(List<Materia> materias)
        {
            Materias = materias;
            InitializeComponent();
            CarregarDisciplinas();
        }

        private void CarregarDisciplinas()
        {
            cbxDisciplina.Items.Clear();
            foreach (int i in Enum.GetValues(typeof(DisciplinaEnum)))
            {
                cbxDisciplina.Items.Add((DisciplinaEnum)i);
            }

            for (int i = 0; i < alternativas.Length; i++)
            {
                cbxGabarito.Items.Add(alternativas[i]);
            }
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
                cbxDisciplina.SelectedItem = questao.disciplina;
                cbxMateria.SelectedItem = questao.materia;
                txtTitulo.Text = questao.titulo;
                txtEnunciado.Text = questao.enunciado;
                txtA.Text = questao.a;
                txtB.Text = questao.b;
                txtC.Text = questao.c;
                txtD.Text = questao.d;
                cbxGabarito.Text = questao.gabarito;
            }
        }

        private void cbxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplinaEnum disciplina= (DisciplinaEnum)cbxDisciplina.SelectedItem;
            CarregarMaterias(Materias,disciplina);
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            questao.disciplina = (DisciplinaEnum)cbxDisciplina.SelectedItem;
            questao.materia = (Materia)cbxMateria.SelectedItem;
            questao.titulo = txtTitulo.Text;
            questao.enunciado = txtEnunciado.Text;
            questao.a = txtA.Text;
            questao.b = txtB.Text;
            questao.c = txtC.Text;
            questao.d = txtD.Text;
            questao.gabarito = cbxGabarito.Text;


            var resultadoValidacao = GravarRegistro(questao);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void CarregarMaterias(List<Materia> materiass, DisciplinaEnum disciplina)
        {
            cbxMateria.Items.Clear();
            cbxMateria.Text = "";

            foreach(Materia materia in materiass)
            {
                if(materia.disciplina == disciplina)
                {
                    cbxMateria.Items.Add(materia);
                }
            }

        }

    }
}
