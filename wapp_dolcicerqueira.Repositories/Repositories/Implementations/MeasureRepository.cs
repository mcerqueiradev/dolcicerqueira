using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class MeasureRepository : IMeasureRepository
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public Measure Add(Measure measure)
        {
            string query = "AddMeasure";

            SqlParameter unitParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Unit",
                Value = measure.Unit
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(unitParam);

            _sqlConnection.Open();

            measure.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return measure;
        }

        public void Delete(int id)
        {
            string query = "DeleteMeasure";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = id
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public Measure GetById(int id)
        {
            Measure measureResult = null;

            string query = "GetMeasureById";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = id
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(searchParam);

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                measureResult = new Measure
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Unit = Convert.ToString(readerTable["Unit"])
                };
            }

            _sqlConnection.Close();

            return measureResult;
        }

        public List<Measure> GetAll()
        {
            List<Measure> measuresResult = new List<Measure>();

            string query = "GetAllMeasures";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                measuresResult.Add(
                    new Measure
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        Unit = Convert.ToString(readerTable["Unit"])
                    });
            }

            _sqlConnection.Close();

            return measuresResult;
        }

        public Measure Update(Measure measure)
        {
            string query = "UpdateMeasure";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = measure.Id
            };

            SqlParameter unitParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Unit",
                Value = measure.Unit
            };


            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(unitParam);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

            return measure;
        }
    }
}
