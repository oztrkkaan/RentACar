using System.Data.SqlClient;

namespace DataAccess.Abstract
{
    public interface IDatabaseContext
    {
        SqlConnection Connection { get; }
        void Dispose();
    }
}
