using AUP_Problem_01.Helpers;

namespace AUP_Problem_01
{
    public class Solution01
    {
        public void Solve()
        {

            // Read the data from a CSV file
            var investors = new DataSetReader().ReadDataFromCsv("transactions.csv");

            // Group the data by investor ID
            var groupedData = investors.GroupBy(x => x.InvestorId)
                .Select(g => new
                {
                    InvestorID = g.Key,
                    UniqueSyndicates = g.Select(x => x.SyndicateId).Distinct().Count(),
                    TotalAmountInvested = g.Sum(x => x.Amount)
                });

            // Sort the data by the number of unique syndicates in descending order
            var sortedData = groupedData.OrderByDescending(x => x.UniqueSyndicates).Take(5);

            // Print the top 5 investors
            Console.WriteLine("Top 5 Investors with the highest number of unique syndicates and their total investment amounts:");
            foreach (var item in sortedData)
            {
                Console.WriteLine($"Investor ID: {item.InvestorID}, Unique Syndicates: {item.UniqueSyndicates}, Total Amount Invested: {item.TotalAmountInvested}");
            }
        }
    }
}
