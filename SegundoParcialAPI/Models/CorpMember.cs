using System;
using System.Collections.Generic;

namespace SegundoParcialAPI.Models;

public partial class CorpMember
{
    public int MemberNo { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Middleinitial { get; set; }

    public int CorpNo { get; set; }

    public string CorpName { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string StateProv { get; set; } = null!;

    public string MailCode { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public DateTime ExprDt { get; set; }

    public int RegionNo { get; set; }

    public string CorpCode { get; set; } = null!;
}
