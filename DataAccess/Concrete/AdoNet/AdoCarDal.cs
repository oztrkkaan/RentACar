using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.AdoNet
{
    public class AdoCarDal : ICarDal
    {
        private IDatabaseContext _databaseContext;
        private SqlConnection _connection;

        public AdoCarDal(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _connection = _databaseContext.Connection;
        }
        protected void SpInsertCarParameters(Car car, SqlCommand cmd)
        {
            cmd.CommandText = "spInsertCar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Brand", car.Brand);
            cmd.Parameters.AddWithValue("@Model", car.Model);
            cmd.Parameters.AddWithValue("@ModelYear", car.ModelYear);
            cmd.Parameters.AddWithValue("@CarPlate", car.CarPlate);
            cmd.Parameters.AddWithValue("@VIN", car.VIN);
            cmd.Parameters.AddWithValue("@Color", car.Color);
            cmd.Parameters.AddWithValue("@DailyRentCost", car.DailyRentCost);
            cmd.Parameters.AddWithValue("@Type", car.Type);
            cmd.Parameters.AddWithValue("@Currency", car.Currency);
        }

        protected void SpGetAllCarsParameters(SqlCommand cmd)
        {
            cmd.CommandText = "spGetAllCars";
            cmd.CommandType = CommandType.StoredProcedure;
        }
        protected void SpGetCarByIdParameters(int carId, SqlCommand cmd)
        {
            cmd.CommandText = "spGetCarById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", carId);
        }

        public IDataResult<IList<Car>> GetAll()
        {
            using (var cmd = _connection.CreateCommand())
            {
                SpGetAllCarsParameters(cmd);
                SqlDataReader dataReader = cmd.ExecuteReader();

                IList<Car> Cars = new List<Car>();

                while (dataReader.Read())
                {
                    Cars.Add(new Car
                    {
                        Brand = dataReader["Brand"].ToString(),
                        CarPlate = dataReader["CarPlate"].ToString(),
                        Color = dataReader["Color"].ToString(),
                        Currency = byte.Parse(dataReader["Currency"].ToString()),
                        DailyRentCost = decimal.Parse(dataReader["Currency"].ToString()),
                        Model = dataReader["Model"].ToString(),
                        Id = int.Parse(dataReader["Id"].ToString()),
                        ModelYear = short.Parse(dataReader["ModelYear"].ToString()),
                        Type = byte.Parse(dataReader["Type"].ToString()),
                        VIN = dataReader["VIN"].ToString()
                    });
                }
                return new SuccessDataResult<IList<Car>>(Cars);
            }
        }
        public IDataResult<Car> Add(Car car)
        {
            using (var cmd = _connection.CreateCommand())
            {
                SpInsertCarParameters(car, cmd);
                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                var addedCar = new Car
                {
                    Brand = dataReader["Brand"].ToString(),
                    CarPlate = dataReader["CarPlate"].ToString(),
                    Color = dataReader["Color"].ToString(),
                    Currency = byte.Parse(dataReader["Currency"].ToString()),
                    DailyRentCost = decimal.Parse(dataReader["Currency"].ToString()),
                    Model = dataReader["Model"].ToString(),
                    Id = int.Parse(dataReader["Id"].ToString()),
                    ModelYear = short.Parse(dataReader["ModelYear"].ToString()),
                    Type = byte.Parse(dataReader["Type"].ToString()),
                    VIN = dataReader["VIN"].ToString()
                };

                _connection.Dispose();

                return new SuccessDataResult<Car>(addedCar);
            }
        }

        public IDataResult<Car> GetById(int id)
        {
            using (var cmd = _connection.CreateCommand())
            {
                SpGetCarByIdParameters(id, cmd);
                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                var car = new Car
                {
                    Brand = dataReader["Brand"].ToString(),
                    CarPlate = dataReader["CarPlate"].ToString(),
                    Color = dataReader["Color"].ToString(),
                    Currency = byte.Parse(dataReader["Currency"].ToString()),
                    DailyRentCost = decimal.Parse(dataReader["Currency"].ToString()),
                    Model = dataReader["Model"].ToString(),
                    Id = int.Parse(dataReader["Id"].ToString()),
                    ModelYear = short.Parse(dataReader["ModelYear"].ToString()),
                    Type = byte.Parse(dataReader["Type"].ToString()),
                    VIN = dataReader["VIN"].ToString()
                };
                _connection.Dispose();
                return new SuccessDataResult<Car>(car);
            }
        }
    }
}
