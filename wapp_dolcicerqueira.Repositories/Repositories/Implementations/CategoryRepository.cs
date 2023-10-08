using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);

        public Category Add(Category category)
        {
            string query = "AddCategory";

            SqlParameter titleParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Name",
                Value = category.Name
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(titleParam);

            _sqlConnection.Open();

            category.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return category;
        }

        public void Delete(int id)
        {
            string query = "DeleteCategory";

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

        public Category GetById(int id)
        {
            Category categoryResult = null;

            string query = "GetCategoryById";

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
                categoryResult = new Category
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Name = Convert.ToString(readerTable["Name"]),
                };
            }

            _sqlConnection.Close();

            return categoryResult;
        }

        public List<Category> GetAll()
        {
            List<Category> categoryResult = new List<Category>();

            string query = "GetAllCategory";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                categoryResult.Add(
                    new Category
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        Name = Convert.ToString(readerTable["Name"]),
                    });
            }

            _sqlConnection.Close();

            return categoryResult;
        }

        public Category Update(Category category)
        {
            string query = "UpdateCategory";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = category.Id
            };

            SqlParameter titleParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Name",
                Value = category.Name
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(titleParam);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

            return category;
        }
    }
}
