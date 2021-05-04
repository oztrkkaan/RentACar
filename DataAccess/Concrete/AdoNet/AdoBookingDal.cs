using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Concrete.AdoNet
{
    public class AdoBookingDal : IBookingDal
    {
        private IDatabaseContext _databaseContext;

        public AdoBookingDal(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
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
        protected void SpGetAllBookingsByCarIdParameters(int carId, SqlCommand cmd)
        {
            cmd.CommandText = "spGetAllBookingsByCarId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CarId", carId);
        }

        public IDataResult<BookingDto> Add(Entity.Dtos.BookingDto bookingDto)
        {
            using (var _connection = new SqlConnection(_databaseContext.ConnectionString))
            {
                _connection.Open();

                using (var cmd = _connection.CreateCommand())
                {
                    SpInsertBookingParameters(bookingDto, cmd);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();
                    var booking = new BookingDto()
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

                    return new SuccessDataResult<BookingDto>(booking, "Rezervasyon başarıyla kaydedildi.");
                }
            }
        }

        public IDataResult<IList<BookingDto>> GetListByCarId(int carId)
        {
            using (var _connection = new SqlConnection(_databaseContext.ConnectionString))
            {
                _connection.Open();

                using (var cmd = _connection.CreateCommand())
                {
                    SpGetAllBookingsByCarIdParameters(carId, cmd);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    IList<BookingDto> bookingDtos = new List<BookingDto>();
                    while (dataReader.Read())
                    {
                        bookingDtos.Add( new BookingDto()
                        {
                            Amount = decimal.Parse(dataReader["Amount"].ToString()),
                            BookingDate = DateTime.Parse(dataReader["BookingDate"].ToString()),
                            BookingEndDate = DateTime.Parse(dataReader["BookingEndDate"].ToString()),
                            BookingTime = short.Parse(dataReader["BookingTime"].ToString()),
                            CarId = int.Parse(dataReader["CarId"].ToString()),
                            CustomerId = int.Parse(dataReader["CustomerId"].ToString()),
                            Id = int.Parse(dataReader["Id"].ToString()),
                            CustomerName = dataReader["FullName"].ToString()
                        });
                    }
                    return new SuccessDataResult<IList<BookingDto>>(bookingDtos, "Rezervasyon başarıyla kaydedildi.");
                }
            }
        }
    }
}
