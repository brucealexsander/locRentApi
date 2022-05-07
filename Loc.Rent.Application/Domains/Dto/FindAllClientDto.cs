using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.Domains.Dto
{
    public class FindAllClientDto
    {
        public FindAllClientDto(string cpf, string name)
        {
            Cpf = cpf;
            Name = name;
        }

        public string Cpf { get; set; }
        public string Name { get; set; }
    }
}
