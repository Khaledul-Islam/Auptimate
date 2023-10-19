namespace AUP_Problem_02.Models
{
    public class Transaction
    {
        public string? SyndicateId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}
