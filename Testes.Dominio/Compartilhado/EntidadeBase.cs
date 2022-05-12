using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public int Numero { get; set; }

        public abstract void Atualizar(T registro);
    }
}
