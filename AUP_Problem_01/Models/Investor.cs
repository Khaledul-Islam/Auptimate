using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUP_Problem_01.Models
{
    public class Investor
    {
        public string? InvestorId { get; set; }
        public string? SyndicateId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
