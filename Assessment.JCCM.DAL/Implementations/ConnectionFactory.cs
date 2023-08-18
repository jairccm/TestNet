using Assessment.JCCM.DAL.Interfaces;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace Assessment.JCCM.DAL.Implementations
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["BDTestConnectionString"].ConnectionString;
        public IDbConnection GetConnection
        {
            get
            {
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                return conn;
            }
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
