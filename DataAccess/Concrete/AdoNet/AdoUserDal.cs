using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Concrete.AdoNet
{
    public class AdoUserDal : IUserDal
    {
        private IDatabaseContext _databaseContext;
        private SqlConnection _connection;

        public AdoUserDal(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _connection = _databaseContext.Connection;
        }
        protected void SpInsertUserParameters(User user, SqlCommand cmd)
        {
            cmd.CommandText = "spInsertUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FullName", user.FullName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Roles", user.Roles);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
        }

        protected void SpGetUserByEmail(string email, SqlCommand cmd)
        {
            cmd.CommandText = "spGetUserByEmail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email);
        }
        public IDataResult<User> Add(User user)
        {
            using (var cmd = _connection.CreateCommand())
            {
                SpInsertUserParameters(user, cmd);
                SqlDataReader dataReader = cmd.ExecuteReader();

                var addedUser = new User()
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Email = dataReader["Email"].ToString(),
                    FullName = dataReader["FullName"].ToString(),
                    Roles = dataReader["Roles"].ToString()
                };

                _connection.Dispose();

                return new SuccessDataResult<User>(addedUser);
            }
        }
        public IDataResult<User> GetByMail(string email)
        {
            using (var cmd = _connection.CreateCommand())
            {
                SpGetUserByEmail(email, cmd);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (!dataReader.Read())
                {
                    _connection.Dispose();
                    return new ErrorDataResult<User>("Bu mail ile kayıtlı kullanıcı bulunamadı");
                }

                var user = new User()
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Email = dataReader["Email"].ToString(),
                    FullName = dataReader["FullName"].ToString(),
                    Roles = dataReader["Roles"].ToString(),
                    PasswordHash = (byte[])dataReader["PasswordHash"],
                    PasswordSalt = (byte[])dataReader["PasswordSalt"]
                };
                _connection.Dispose();
                return new SuccessDataResult<User>(user);
            }
        }
    }
}
