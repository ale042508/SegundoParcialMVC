using System;
using System.Collections.Generic;

namespace SegundoParcialAPI.Models;

public partial class StatementWide
{
    public int MemberNo { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Middleinitial { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string StateProv { get; set; } = null!;

    public string MailCode { get; set; } = null!;

    public string? PhoneNo { get; set; }

    public DateTime ExprDt { get; set; }

    public string MemberCode { get; set; } = null!;

    public int RegionNo { get; set; }

    public string RegionName { get; set; } = null!;

    public int StatementNo { get; set; }

    public DateTime StatementDt { get; set; }

    public DateTime DueDt { get; set; }

    public decimal StatementAmt { get; set; }

    public string StatementCode { get; set; } = null!;
}
