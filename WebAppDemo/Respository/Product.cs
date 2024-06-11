using System;
using System.Collections.Generic;

namespace Respository;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public int? Qty { get; set; }

    public virtual Category Category { get; set; } = null!;
}
