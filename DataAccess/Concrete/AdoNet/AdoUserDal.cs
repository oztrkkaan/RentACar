using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.AdoNet.Contexts;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Dtos.Web.Auth;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Concrete.AdoNet
{
    public class AdoUserDal : IUserDal
    {
        private IDatabaseContext _databaseContext;
        private SqlConnection _connection;

        public AdoUserDal()
        {
            _databaseContext = new DatabaseContext();
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
        public IDataResult<User> Add(User user)
        {
            using (var cmd = _connection.CreateCommand())
            {
                SpInsertUserParameters(user, cmd);
                int affectedRowsCount = cmd.ExecuteNonQuery();
                return new SuccessDataResult<User>(new User());
            }
        }
    }
}
