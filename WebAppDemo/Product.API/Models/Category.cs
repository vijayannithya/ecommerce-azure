using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{

    public partial class Category
    {
        public Category()
        { }

        [Key]
        public int category_id { get; set; }

        public string? category_name { get; set; }

    }
}