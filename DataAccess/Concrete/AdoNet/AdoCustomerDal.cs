using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.Web.Panel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Concrete.AdoNet
{
    public class AdoCustomerDal : ICustomerDal
    {
        private IDatabaseContext _databaseContext;


        public AdoCustomerDal(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

        }
        protected void SpGetAllCustomersParameters(SqlCommand cmd)
        {
            cmd.CommandText = "spGetAllCustomers";
            cmd.CommandType = CommandType.StoredProcedure;
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
            using (var _connection = new SqlConnection(_databaseContext.ConnectionString))
            {
                _connection.Open();
                using (var cmd = _connection.CreateCommand())
                {
                    SpInsertCustomerParameters(createCustomerDto, cmd);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    var customer = new Customer
                    {
                        BirthDate = DateTime.Parse(dataReader["BirthDate"].ToString()),
                        CitizenshipNumber = long.Parse(dataReader["CitizenshipNumber"].ToString()),
                        FullName = dataReader["FullName"].ToString(),
                        Gender = short.Parse(dataReader["Gender"].ToString()),
                        Id = int.Parse(dataReader["Id"].ToString())
                    };
                    return new SuccessDataResult<Customer>(customer);
                }
            }
        }

        public IDataResult<IList<Customer>> GetAll()
        {
            using (var _connection = new SqlConnection(_databaseContext.ConnectionString))
            {
                _connection.Open();

                using (var cmd = _connection.CreateCommand())
                {

                    SpGetAllCustomersParameters(cmd);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    IList<Customer> customers = new List<Customer>();
                    while (dataReader.Read())
                    {
                        customers.Add(new Customer
                        {
                            BirthDate = DateTime.Parse(dataReader["BirthDate"].ToString()),
                            CitizenshipNumber = long.Parse(dataReader["CitizenshipNumber"].ToString()),
                            FullName = dataReader["FullName"].ToString(),
                            Gender = short.Parse(dataReader["Gender"].ToString()),
                            Id = int.Parse(dataReader["Id"].ToString())
                        });
                    }
                    return new SuccessDataResult<IList<Customer>>(customers);
                }
            }
        }
    }
}
