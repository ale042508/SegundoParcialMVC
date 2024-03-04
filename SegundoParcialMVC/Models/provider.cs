namespace SegundoParcialMVC.Models
{
    public class provider
    {
        public int ProviderNo { get; set; }

        public string ProviderName { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public string StateProv { get; set; } = null!;

        public string MailCode { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public DateTime IssueDt { get; set; }

        public DateTime ExprDt { get; set; }

        public int RegionNo { get; set; }

        public string ProviderCode { get; set; } = null!;

    }
}
