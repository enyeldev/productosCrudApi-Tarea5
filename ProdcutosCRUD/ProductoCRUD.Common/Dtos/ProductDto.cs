﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoCRUD.Common.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int Stock { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
