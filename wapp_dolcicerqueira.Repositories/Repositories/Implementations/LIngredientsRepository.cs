using wapp_dolcicerqueira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using wapp_dolcicerqueira.Repositories.Repositories.Interfaces;

namespace wapp_dolcicerqueira.Repositories.Repositories.Implementations
{
    public class LIngredientsRepository : ILIngredientsRepository
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public LIngredients Add(LIngredients lIngredients)
        {
            string query = "AddListIngredients";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IngredientId",
                DbType = DbType.Int32,
                Value = lIngredients.IngredientId
            };

            SqlParameter idRecipeParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RecipeId",
                DbType = DbType.Int32,
                Value = lIngredients.RecipeId
            };

            SqlParameter measureParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MeasureId",
                DbType = DbType.Int32,
                Value = lIngredients.MeasureId
            };

            SqlParameter qtyParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Quantity",
                DbType = DbType.Decimal,
                Value = lIngredients.Quantity
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(idRecipeParam);
            sqlCommand.Parameters.Add(measureParam);
            sqlCommand.Parameters.Add(qtyParam);

            _sqlConnection.Open();

            lIngredients.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return lIngredients;
        }

        public List<LIngredients> GetByIdRecipe(int id)
        {
            List<LIngredients> lingredientsResult = new List<LIngredients>();

            string query = "GetIngredientByRecipeId";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RecipeId",
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
                lingredientsResult.Add(
                    new LIngredients
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        IngredientId = Convert.ToInt32(readerTable["IngredientId"]),
                        RecipeId = Convert.ToInt32(readerTable["RecipeId"]),
                        Quantity = Convert.ToDecimal(readerTable["Quantity"]),
                        MeasureId = Convert.ToInt32(readerTable["MeasureId"]),  
                        Unit = Convert.ToString(readerTable["Unit"]),
                        Name = Convert.ToString(readerTable["Name"])
                    });
            }

            _sqlConnection.Close();

            return lingredientsResult;
        }

        public List<LIngredients> SelectIngredientsByRecipe(int id)
        {
            List<LIngredients> lingredientsResult = new List<LIngredients>();

            string query = "GetIngredientByRecipeId";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RecipeId",
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
                lingredientsResult.Add(
                    new LIngredients
                    {
                        IngredientId = Convert.ToInt32(readerTable["IngredientId"]),
                        RecipeId = Convert.ToInt32(readerTable["RecipeId"]),
                        Quantity = Convert.ToDecimal(readerTable["Quantity"]),
                        MeasureId = Convert.ToInt32(readerTable["MeasureId"]),
                        Unit = Convert.ToString(readerTable["Unit"]),
                        Name = Convert.ToString(readerTable["Name"])
                    });
            }

            _sqlConnection.Close();

            return lingredientsResult;
        }
        public void Delete(int id)
        {
            string query = "DeleteLIngredients";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RecipeId",
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
        public List<LIngredients> GetAll()
        {
            List<LIngredients> lIngredientsResult = new List<LIngredients>();

            string query = "GetAllListIngredients";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                lIngredientsResult.Add(
                    new LIngredients()
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        Quantity = Convert.ToDecimal(readerTable["Quantity"]),
                        Unit = Convert.ToString(readerTable["Unit"]),
                        Name = Convert.ToString(readerTable["Name"])
                    }
                );
            }

            _sqlConnection.Close();

            return lIngredientsResult;
        }
        public LIngredients Update(LIngredients lIngredients)
        {
            string query = "UpdateListIngredients";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IngredientId",
                DbType = DbType.Int32,
                Value = lIngredients.IngredientId
            };

            SqlParameter idRecipeParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RecipeId",
                DbType = DbType.Int32,
                Value = lIngredients.RecipeId
            };

            SqlParameter measureParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MeasureId",
                DbType = DbType.Int32,
                Value = lIngredients.MeasureId
            };

            SqlParameter qtyParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Quantity",
                DbType = DbType.Decimal,
                Value = lIngredients.Quantity
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(idRecipeParam);
            sqlCommand.Parameters.Add(measureParam);
            sqlCommand.Parameters.Add(qtyParam);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

            return lIngredients;
        }
    }
}
