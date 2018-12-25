using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace AdventureWorks.DbModel
{
    public class ConnectionStringBuilder
    {
        public static string Construct(string connectionString)
        {
            var entityConnectionBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = connectionString,
                Metadata = "res://*"
            };

            return entityConnectionBuilder.ToString();
        }
    }
}
