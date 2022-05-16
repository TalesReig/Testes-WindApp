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
using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloMatérias
{
    public partial class TabelaMateriasControl : UserControl
    {
        public TabelaMateriasControl()
        {
            InitializeComponent();
            tabelaMaterias.ConfigurarGridZebrado();
            tabelaMaterias.ConfigurarGridSomenteLeitura();
            tabelaMaterias.Columns.AddRange(ObterColunas());
        }
        public int ObtemNumeroMateriaSelecionado()
        {
            return tabelaMaterias.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Materia> materias)
        {
            tabelaMaterias.Rows.Clear();

            foreach (Materia m in materias)
            {
                tabelaMaterias.Rows.Add(m.Numero,m.disciplina, m.nome, m.turma);
            }
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {   
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "ID"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Matéria"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Serie", HeaderText = "Série"},
            };

            return colunas;
        }

    }
}
