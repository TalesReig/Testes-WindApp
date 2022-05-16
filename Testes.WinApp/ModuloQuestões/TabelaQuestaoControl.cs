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
using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloQuestões
{
    public partial class TabelaQuestaoControl : UserControl
    {
        public TabelaQuestaoControl()
        {
            InitializeComponent();
            tabelaQuestoes.ConfigurarGridZebrado();
            tabelaQuestoes.ConfigurarGridSomenteLeitura();
            tabelaQuestoes.Columns.AddRange(ObterColunas());
        }
        public int ObtemNumeroQuestaoSelecionado()
        {
            return tabelaQuestoes.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Questao> materias)
        {
            tabelaQuestoes.Rows.Clear();

            foreach (Questao m in materias)
            {
                tabelaQuestoes.Rows.Add(m.Numero, m.titulo, m.disciplina, m.materia );
            }
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Titulo", HeaderText = "Título"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Matéria"},

            };

            return colunas;
        }
    }
}
