using System.Data.SqlClient;

namespace DataAccess.Abstract
{
    public interface IDatabaseContext
    {
        string ConnectionString { get; }
    }
}
