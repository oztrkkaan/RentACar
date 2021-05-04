using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Concrete.AdoNet
{
    public class AdoBookingDal : IBookingDal
    {
        private IDatabaseContext _databaseContext;
        private SqlConnection _connection;

        public AdoBookingDal(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _connection = _databaseContext.Connection;
        }

        protected void SpInsertBookingParameters(Entity.Dtos.BookingDto bookingDto, SqlCommand cmd)
        {
            cmd.CommandText = "spInsertBooking";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerId", bookingDto.CustomerId);
            cmd.Parameters.AddWithValue("@CarId", bookingDto.CarId);
            cmd.Parameters.AddWithValue("@BookingDate", bookingDto.BookingDate);
            cmd.Parameters.AddWithValue("@BookingEndDate", bookingDto.BookingEndDate);
        }

        public IDataResult<Entity.Concrete.BookingDto> Add(Entity.Dtos.BookingDto bookingDto)
        {
            using (var cmd = _connection.CreateCommand())
            {
                SpInsertBookingParameters(bookingDto, cmd);
                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                var booking = new Entity.Concrete.BookingDto()
                {
                    Amount = decimal.Parse(dataReader["Amount"].ToString()),
                    BookingDate = DateTime.Parse(dataReader["BookingDate"].ToString()),
                    BookingEndDate = DateTime.Parse(dataReader["BookingEndDate"].ToString()),
                    BookingTime = short.Parse(dataReader["BookingTime"].ToString()),
                    CarId = int.Parse(dataReader["CarId"].ToString()),
                    CustomerId = int.Parse(dataReader["CustomerId"].ToString()),
                    Id = int.Parse(dataReader["Id"].ToString()),
                    CustomerName = dataReader["FullName"].ToString()

                };

                _connection.Dispose();
                return new SuccessDataResult<Entity.Concrete.BookingDto>(booking, "Rezervasyon başarıyla kaydedildi.");
            }
        }
    }
}
