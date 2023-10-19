using AUP_Problem_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUP_Problem_02.Services
{
    public class AlertingService
    {
        private const decimal PredefinedThreshold = 10000; // Example threshold
        private readonly Dictionary<string, int> transactionRates = new Dictionary<string, int>();

        public void ProcessTransaction(Transaction transaction)
        {
            CheckThresholdExceeding(transaction);
            UpdateTransactionRates(transaction);
            CheckTransactionSpike(transaction);
        }

        private void CheckThresholdExceeding(Transaction transaction)
        {
            if (transaction.Amount > PredefinedThreshold)
            {
                var alert = new Alert { AlertMessage = $"Threshold Exceeded for Syndicate: {transaction.SyndicateId}", AlertTime = DateTime.Now };
                NotifyFundManagers(alert);
            }
        }

        private void UpdateTransactionRates(Transaction transaction)
        {
            if (transaction.SyndicateId != null && transactionRates.ContainsKey(transaction.SyndicateId))
            {
                transactionRates[transaction.SyndicateId]++;
            }
            else
            {
                if (transaction.SyndicateId != null) transactionRates[transaction.SyndicateId] = 1;
            }
        }

        private void CheckTransactionSpike(Transaction transaction)
        {
            var averageRate = CalculateAverageRate(transaction.TransactionTime);
            if (transaction.SyndicateId != null && transactionRates[transaction.SyndicateId] > 10 * averageRate)
            {
                var alert = new Alert { AlertMessage = $"Transaction Spike Detected for Syndicate: {transaction.SyndicateId}", AlertTime = DateTime.Now };
                NotifyFundManagers(alert);
            }
        }

        private double CalculateAverageRate(DateTime currentTransactionTime)
        {
            // Simulating the sliding window calculation for the average rate
            // In a real application, this should involve actual sliding window logic
            var random = new Random();
            return random.Next(1, 100);
        }

        private void NotifyFundManagers(Alert alert)
        {
            // Simulating the notification mechanism
            Console.WriteLine($"Sending Alert - {alert.AlertMessage} at {alert.AlertTime}");
        }
    }
}
