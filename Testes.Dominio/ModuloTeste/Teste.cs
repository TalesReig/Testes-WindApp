using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.Compartilhado;

namespace Testes.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string titulo { get; set; }
        public override void Atualizar(Teste registro)
        {
            this.titulo = registro.titulo;
        }
    }
}
