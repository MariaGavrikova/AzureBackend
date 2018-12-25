using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace AdventureWorks.DbModel
{
    public partial class Entities : DbContext
    {
        public Entities(string connectionString) : base(ConnectionStringBuilder.Construct(connectionString))
        {
        }
    }
}
