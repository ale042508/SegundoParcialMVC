using System;
using System.Collections.Generic;

namespace SegundoParcialAPI.Models;

public partial class Payment
{
    public int PaymentNo { get; set; }

    public int MemberNo { get; set; }

    public DateTime PaymentDt { get; set; }

    public decimal PaymentAmt { get; set; }

    public int? StatementNo { get; set; }

    public string PaymentCode { get; set; } = null!;

    public virtual Member MemberNoNavigation { get; set; } = null!;
}
