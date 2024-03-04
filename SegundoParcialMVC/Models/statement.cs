namespace SegundoParcialMVC.Models
{
    public class statement
    {
        public int StatementNo { get; set; }

        public int MemberNo { get; set; }

        public DateTime StatementDt { get; set; }

        public DateTime DueDt { get; set; }

        public decimal StatementAmt { get; set; }

        public string StatementCode { get; set; } = null!;
    }
}
