using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.Web.Panel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.AdoNet
{
    public class AdoCustomerDal : ICustomerDal
    {
        private IDatabaseContext _databaseContext;
        private SqlConnection _connection;

        public AdoCustomerDal( IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

            _connection = _databaseContext.Connection;
        }

        protected void SpInsertCustomerParameters(CreateCustomerDto createCustomerDto, SqlCommand cmd)
        {
            cmd.CommandText = "spInsertCustomer";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FullName", createCustomerDto.FullName);
            cmd.Parameters.AddWithValue("@Gender", createCustomerDto.Gender);
            cmd.Parameters.AddWithValue("@BirthDate", createCustomerDto.BirthDate);
            cmd.Parameters.AddWithValue("@CitizenshipNumber", createCustomerDto.CitizenshipNumber);
            cmd.Parameters.AddWithValue("@CityName", createCustomerDto.CityName);
            cmd.Parameters.AddWithValue("@DistrictName", createCustomerDto.DistrictName);
            cmd.Parameters.AddWithValue("@FullAddress", createCustomerDto.FullAddress);
            cmd.Parameters.AddWithValue("@LandPhone", createCustomerDto.LandPhone);
            cmd.Parameters.AddWithValue("@OfficePhone", createCustomerDto.OfficePhone);
            cmd.Parameters.AddWithValue("@MobilePhone", createCustomerDto.MobilePhone);
        }
        public IDataResult<Customer> AddWithAddressAndPhone(CreateCustomerDto createCustomerDto)
        {
            using (var cmd = _connection.CreateCommand())
            {
                SpInsertCustomerParameters(createCustomerDto, cmd);
                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();

                var customer = new Customer();


                   customer.BirthDate = DateTime.Parse(dataReader["BirthDate"].ToString());
                   customer.CitizenshipNumber = long.Parse(dataReader["CitizenshipNumber"].ToString());
                   customer.FullName = dataReader["FullName"].ToString();
                   customer.Gender = short.Parse(dataReader["Gender"].ToString());
                   customer.Id = int.Parse(dataReader["Id"].ToString());
                

                _connection.Dispose();
                return new SuccessDataResult<Customer>(customer);
            }
        }
    }
}
