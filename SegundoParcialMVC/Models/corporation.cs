namespace SegundoParcialMVC.Models
{
    public class corporation
    {
        public int CorpNo { get; set; }

        public string CorpName { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public string StateProv { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string MailCode { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public DateTime ExprDt { get; set; }

        public int RegionNo { get; set; }

        public string CorpCode { get; set; } = null!;
    }
}
