namespace SegundoParcialMVC.Models
{
    public class payment
    {
        public int PaymentNo { get; set; }

        public int MemberNo { get; set; }

        public DateTime PaymentDt { get; set; }

        public decimal PaymentAmt { get; set; }

        public int? StatementNo { get; set; }

        public string PaymentCode { get; set; } = null!;
    }
}
