using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceFinanciero.Repository
{
    public class PostgresConfiguration
    {
        public string ConnectionString { get; set; }
        public PostgresConfiguration(string connectionString) => ConnectionString = connectionString;
    }
}
