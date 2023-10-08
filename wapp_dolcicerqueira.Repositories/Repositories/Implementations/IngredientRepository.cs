using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class IngredientRepository : IIngredientRepository
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public Ingredient Add(Ingredient ingredient)
        {
            string query = "AddIngredient";

            SqlParameter titleParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Name",
                Value = ingredient.Name
            };            

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(titleParam);

            _sqlConnection.Open();

            ingredient.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return ingredient;
        }

        public void Delete(int id)
        {
            string query = "DeleteIngredient";

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

        public Ingredient GetById(int id)
        {
            Ingredient ingredientResult = null;

            string query = "GetIngredientById";

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
                ingredientResult = new Ingredient
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Name = Convert.ToString(readerTable["Name"]),
                };
            }

            _sqlConnection.Close();

            return ingredientResult;
        }

        public List<Ingredient> GetAll()
        {
            List<Ingredient> ingredientsResult = new List<Ingredient>();

            string query = "GetAllIngredients";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                ingredientsResult.Add(
                    new Ingredient
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        Name = Convert.ToString(readerTable["Name"]),
                    });
            }

            _sqlConnection.Close();

            return ingredientsResult;
        }

        public Ingredient Update(Ingredient ingredient)
        {
            string query = "UpdateIngredient";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = ingredient.Id
            };

            SqlParameter titleParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Name",
                Value = ingredient.Name
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(titleParam);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

            return ingredient;
        }
    }
}
