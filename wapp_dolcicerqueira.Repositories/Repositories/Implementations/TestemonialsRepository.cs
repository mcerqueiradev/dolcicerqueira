using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using wapp_dolcicerqueira.Repositories.Repositories.Interfaces;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class TestemonialsRepository : ITestemonialsRepository
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public Testemonials Add(Testemonials testemonials)
        {
            string query = "AddTestemonials";

            SqlParameter nameParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Name",
                Value = testemonials.Name
            };

            SqlParameter emailParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Email",
                Value = testemonials.Email
            };

            SqlParameter messageParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Message",
                Value = testemonials.Message
            };

            SqlParameter dataParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Data",
                Value = DateTime.Now
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(nameParam);
            sqlCommand.Parameters.Add(emailParam);
            sqlCommand.Parameters.Add(messageParam);
            sqlCommand.Parameters.Add(dataParam);

            _sqlConnection.Open();

            testemonials.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return testemonials;
        }

        public Testemonials Update(Testemonials testemonials)
        {
            string query = "UpdateTestemonials";

            SqlParameter nameParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Name",
                Value = testemonials.Name
            };

            SqlParameter emailParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Email",
                Value = testemonials.Email
            };

            SqlParameter messageParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Message",
                Value = testemonials.Message
            };

            SqlParameter dataParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Data",
                Value = testemonials.Data
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(nameParam);
            sqlCommand.Parameters.Add(emailParam);
            sqlCommand.Parameters.Add(messageParam);
            sqlCommand.Parameters.Add(dataParam);

            _sqlConnection.Open();

            testemonials.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return testemonials;
        }
        public void Delete(int id)
        {
            string query = "DeleteTestemonials";

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

        public Testemonials GetById(int id)
        {
            Testemonials testemonialsResult = null;

            string query = "GetTestemonialsById";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RatingId",
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
                testemonialsResult = new Testemonials
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Name = Convert.ToString(readerTable["Name"]),
                    Email = Convert.ToString(readerTable["Email"]),
                    Message = Convert.ToString(readerTable["Message"]),
                    Data = Convert.ToDateTime(readerTable["Data"])
                };
            }

            _sqlConnection.Close();

            return testemonialsResult;
        }

        public List<Testemonials> GetAll()
        {
            List<Testemonials> testemonialsResult = new List<Testemonials>();

            string query = "GetAllTestemonials";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                testemonialsResult.Add(
                    new Testemonials
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        Name = Convert.ToString(readerTable["Name"]),
                        Email = Convert.ToString(readerTable["Email"]),
                        Message = Convert.ToString(readerTable["Message"]),
                        Data = Convert.ToDateTime(readerTable["Data"])
                    });
            }

            _sqlConnection.Close();

            return testemonialsResult;
        }

    }
}
