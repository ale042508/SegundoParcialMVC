using System;
using System.Collections.Generic;

namespace SegundoParcialAPI.Models;

public partial class Region
{
    public int RegionNo { get; set; }

    public string RegionName { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string StateProv { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string MailCode { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string RegionCode { get; set; } = null!;

    public virtual ICollection<Corporation> Corporations { get; set; } = new List<Corporation>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
}
