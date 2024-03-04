using System;
using System.Collections.Generic;

namespace SegundoParcialAPI.Models;

public partial class ChargeWide
{
    public int MemberNo { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public int RegionNo { get; set; }

    public string RegionName { get; set; } = null!;

    public string ProviderName { get; set; } = null!;

    public string CategoryDesc { get; set; } = null!;

    public int ChargeNo { get; set; }

    public int ProviderNo { get; set; }

    public int CategoryNo { get; set; }

    public DateTime ChargeDt { get; set; }

    public decimal ChargeAmt { get; set; }

    public string ChargeCode { get; set; } = null!;
}
