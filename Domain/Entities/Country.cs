﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public List<City> Cities { get; set; }
    }
}
