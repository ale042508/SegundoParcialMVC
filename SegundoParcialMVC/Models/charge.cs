namespace SegundoParcialMVC.Models
{
    public class charge
    {
        public int ChargeNo { get; set; }

        public int MemberNo { get; set; }

        public int ProviderNo { get; set; }

        public int CategoryNo { get; set; }

        public DateTime ChargeDt { get; set; }

        public decimal ChargeAmt { get; set; }

        public int StatementNo { get; set; }

        public string ChargeCode { get; set; } = null!;
    }
}
