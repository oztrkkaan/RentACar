using DataAccess.Abstract;
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
            _connectionString = @"Server=(localdb)\mssqllocaldb; Database=RentACarDb; Trusted_Connection=true"; //ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }
        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}