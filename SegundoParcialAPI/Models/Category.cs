using System;
using System.Collections.Generic;

namespace SegundoParcialAPI.Models;

public partial class Category
{
    public int CategoryNo { get; set; }

    public string CategoryDesc { get; set; } = null!;

    public string CategoryCode { get; set; } = null!;

    public virtual ICollection<Charge> Charges { get; set; } = new List<Charge>();
}
