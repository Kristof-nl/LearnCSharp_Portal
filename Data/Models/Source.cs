﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Tutorial? Tutorial { get; set; }
    }
}
