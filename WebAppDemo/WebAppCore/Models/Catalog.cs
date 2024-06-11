﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAppCore.Models;
namespace WebAppCore.Models
{
    public class Catalog
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<CatalogItem> Data { get; set; }
    }
}

