using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testes.Dominio.ModuloMatérias;
using Testes.Infra.Arquivos.ModuloMatérias;
using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloMatérias
{
    public class ControladorMateria : ControladorBase
    {
        private RepositorioMateriaEmArquivo repositorioMateria;
        private TabelaMateriasControl tabelaMaterias;


        public ControladorMateria(RepositorioMateriaEmArquivo repositorioMateria)
        {
            this.repositorioMateria = repositorioMateria;
        }

        public override void Inserir()
        {
            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm();
            tela.materia = new Materia();

            tela.GravarRegistro = repositorioMateria.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarMateria();
            }
        }

        public override void Editar()
        {
            Materia materiaSelecionada = ObtemMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Edição de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm();

            tela.materia = materiaSelecionada;

            tela.GravarRegistro = repositorioMateria.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarMateria();
            }
        }
        
        public override void Excluir()
        {
            Materia tarefaSelecionada = ObtemMateriaSelecionada();

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma Materia primeiro",
                "Exclusão de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a tarefa?",
                "Exclusão de Tarefas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioMateria.Excluir(tarefaSelecionada);
                CarregarMateria();
            }
        }

        private void CarregarMateria()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            tabelaMaterias.AtualizarRegistros(materias);
            //TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {tarefas.Count} tarefa(s) {tipoTarefa}");
        }

        public override UserControl ObtemListagem()
        {
            if(tabelaMaterias == null)
                tabelaMaterias = new TabelaMateriasControl();

            CarregarMateria();

            return tabelaMaterias;
        }

        private Materia ObtemMateriaSelecionada()
        {
            var numero = tabelaMaterias.ObtemNumeroMateriaSelecionado();

            return repositorioMateria.SelecionarPorNumero(numero);
        }
    }
}
