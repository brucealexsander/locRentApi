using Loc.Rent.Domain.Entities.Base;

namespace Loc.Rent.Domain.Entities
{
    public class Veiculo : EntityBase
    {
        public virtual string Cor { get; set; }
        public virtual int Descricao { get; set; }
        public virtual int AnoFabricacao { get; set; }
        public virtual int AnoModelo { get; set; }

        public virtual Fabricante Fabricante { get; set; }
               
        public virtual Modelo Modelo { get; set; }
    }
}
