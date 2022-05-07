using Loc.Rent.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loc.Rent.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Cep { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
