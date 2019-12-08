using System.Data.SqlClient;

namespace invert_api.Infrastructure
{
    public class DbContextFactory
    {
        public static SqlConnection GetContext(string connectionString)
        {
            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
