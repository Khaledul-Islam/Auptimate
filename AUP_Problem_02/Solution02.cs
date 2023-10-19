using AUP_Problem_02.Services;
using AUP_Problem_02.Models;

namespace AUP_Problem_02
{
    public class Solution02
    {
        public void Solve()
        {
            var alertingService = new AlertingService();

            // Simulating incoming transactions for testing purposes
            var transaction1 = new Transaction { SyndicateId = "ABC", Amount = 12000, TransactionTime = DateTime.Now };
            var transaction2 = new Transaction { SyndicateId = "XYZ", Amount = 8000, TransactionTime = DateTime.Now };
            var transaction3 = new Transaction { SyndicateId = "ABC", Amount = 1500, TransactionTime = DateTime.Now };

            // Processing transactions
            alertingService.ProcessTransaction(transaction1);
            alertingService.ProcessTransaction(transaction2);
            alertingService.ProcessTransaction(transaction3);
        }
    }
}
