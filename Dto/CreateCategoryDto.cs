﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CreateCategoryDto : IDto
    {
        public string Name { get; set; }
    }
}
