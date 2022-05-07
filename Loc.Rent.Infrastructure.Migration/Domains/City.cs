﻿using Loc.Rent.Domain.Entities.Base;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class City : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual State State { get; set; }
    }
}
