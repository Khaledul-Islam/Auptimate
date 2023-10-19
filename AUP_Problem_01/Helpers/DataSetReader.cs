using AUP_Problem_01.Models;

namespace AUP_Problem_01.Helpers
{
    public class DataSetReader
    {
        // Method to read data from the CSV file
        public List<Investor> ReadDataFromCsv(string filePath)
        {
            List<Investor> investors = new List<Investor>();

            try
            {
                using var reader = new StreamReader(filePath);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line?.Split(',');

                    investors.Add(new Investor
                    {
                        InvestorId = values?[0],
                        SyndicateId = values?[1],
                        Amount = Convert.ToDecimal(values?[2]),
                        TransactionDate = DateTime.Parse(values?[3] ?? string.Empty)
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return investors;
        }
    }
}
