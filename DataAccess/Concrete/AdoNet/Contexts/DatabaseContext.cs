using DataAccess.Abstract;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Concrete.AdoNet.Contexts
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public DatabaseContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SqlConnection(_connectionString);
        }
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

    
    }
}