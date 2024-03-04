﻿using System;
using System.Collections.Generic;

namespace SegundoParcialAPI.Models;

public partial class Member
{
    public int MemberNo { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Middleinitial { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string StateProv { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string MailCode { get; set; } = null!;

    public string? PhoneNo { get; set; }

    public byte[]? Photograph { get; set; }

    public DateTime IssueDt { get; set; }

    public DateTime ExprDt { get; set; }

    public int RegionNo { get; set; }

    public int? CorpNo { get; set; }

    public decimal? PrevBalance { get; set; }

    public decimal? CurrBalance { get; set; }

    public string MemberCode { get; set; } = null!;

    public virtual ICollection<Charge> Charges { get; set; } = new List<Charge>();

    public virtual Corporation? CorpNoNavigation { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Region RegionNoNavigation { get; set; } = null!;

    public virtual ICollection<Statement> Statements { get; set; } = new List<Statement>();
}
