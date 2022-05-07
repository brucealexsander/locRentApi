using Loc.Rent.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loc.Rent.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroCnh { get; set; }
    }
}
