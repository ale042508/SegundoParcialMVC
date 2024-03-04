using System;
using System.Collections.Generic;

namespace SegundoParcialAPI.Models;

public partial class Charge
{
    public int ChargeNo { get; set; }

    public int MemberNo { get; set; }

    public int ProviderNo { get; set; }

    public int CategoryNo { get; set; }

    public DateTime ChargeDt { get; set; }

    public decimal ChargeAmt { get; set; }

    public int StatementNo { get; set; }

    public string ChargeCode { get; set; } = null!;

    public virtual Category CategoryNoNavigation { get; set; } = null!;

    public virtual Member MemberNoNavigation { get; set; } = null!;

    public virtual Provider ProviderNoNavigation { get; set; } = null!;
}
