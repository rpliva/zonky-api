namespace Rpliva.Zonky.Client.Marketplace
{
    public class MyInvestment
    {
        public MyInvestment(int id, double amount, string timeCreated, int investorId, string investorNickname, string status)
        {
            Id = id;
            Amount = amount;
            TimeCreated = timeCreated;
            InvestorId = investorId;
            InvestorNickname = investorNickname;
            Status = status;
        }

        public int Id { get; private set; }
        public double Amount { get; private set; }
        public string TimeCreated { get; private set; }
        public int InvestorId { get; private set; }
        public string InvestorNickname { get; private set; }
        public string Status { get; private set; }
    }
}