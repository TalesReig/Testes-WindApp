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
using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl
    {
        public TabelaTesteControl()
        {
            InitializeComponent();
            tabelaTestes.ConfigurarGridZebrado();
            tabelaTestes.ConfigurarGridSomenteLeitura();
            tabelaTestes.Columns.AddRange(ObterColunas());
        }

        public int ObtemNumeroQuestaoSelecionado()
        {
            return tabelaTestes.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Teste> testes)
        {
            tabelaTestes.Rows.Clear();

            foreach (Teste t in testes)
            {
                tabelaTestes.Rows.Add(t.Numero, t.titulo);
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

        internal object ObtemNumeroTesteSelecionado()
        {
            return tabelaTestes.SelecionarNumero<int>();
        }
    }
}
