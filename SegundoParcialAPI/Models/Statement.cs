using System;
using System.Collections.Generic;

namespace SegundoParcialAPI.Models;

public partial class Statement
{
    public int StatementNo { get; set; }

    public int MemberNo { get; set; }

    public DateTime StatementDt { get; set; }

    public DateTime DueDt { get; set; }

    public decimal StatementAmt { get; set; }

    public string StatementCode { get; set; } = null!;

    public virtual Member MemberNoNavigation { get; set; } = null!;
}
