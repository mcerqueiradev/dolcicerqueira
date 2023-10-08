using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class FavoriteRepository : IFavoriteRepository 
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);

        public Favorite GetById(int id)
        {
            Favorite favoriteResult = null;

            string query = "GetFavoriteById";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@FavoriteId",
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
                favoriteResult = new Favorite
                {
                    FavoriteId = Convert.ToInt32(readerTable["FavoriteId"]),
                    RecipeId = Convert.ToInt32(readerTable["RecipeId"]),
                    UserId = Convert.ToInt32(readerTable["UserId"])
                };
            }

            _sqlConnection.Close();

            return favoriteResult;
        }

        public List<Favorite> GetAll()
        {
            List<Favorite> favoritesResult = new();

            string query = "GetAllFavorite";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                favoritesResult.Add(
                    new Favorite
                    {
                        FavoriteId = Convert.ToInt32(readerTable["FavoriteId"]),
                        RecipeId = Convert.ToInt32(readerTable["RecipeId"]),
                        UserId = Convert.ToInt32(readerTable["UserId"])

                    });
            }
            _sqlConnection.Close();

            return favoritesResult;
        }
        public List<Favorite> GetFavoriteUser(int id)
        {
            List<Favorite> favoriteResult = new();

            string query = "GetFavoriteByIdUser";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserId",
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
                favoriteResult.Add(
                    new Favorite
                    {
                        FavoriteId = Convert.ToInt32(readerTable["FavoriteId"]),
                        RecipeId = Convert.ToInt32(readerTable["RecipeId"]),
                        UserId = Convert.ToInt32(readerTable["UserId"])
                    });
            }

            _sqlConnection.Close();

            return favoriteResult;
        }
        public Favorite Add(Favorite favorite)
        {
            string query = "AddFavorite";

            SqlParameter recipeParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RecipeId",
                Value = favorite.RecipeId
            };

            SqlParameter fk_UserParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserId",
                Value = favorite.UserId
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(recipeParam);
            sqlCommand.Parameters.Add(fk_UserParam);

            _sqlConnection.Open();

            favorite.FavoriteId = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return favorite;
        }

        public Favorite Update(Favorite favorite)
        {
   
            string query = "UpdateFavorite";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@FavoriteId",
                DbType = DbType.Int32,
                Value = favorite.FavoriteId
            };

            SqlParameter recipeParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RecipeId",
                Value = favorite.RecipeId
            };

            SqlParameter fk_UserParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserId",
                Value = favorite.UserId
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(recipeParam);
            sqlCommand.Parameters.Add(fk_UserParam);

            _sqlConnection.Open();

            favorite.FavoriteId = Convert.ToInt32(sqlCommand.ExecuteNonQuery());
            favorite.RecipeId = Convert.ToInt32(sqlCommand.ExecuteNonQuery());
            favorite.UserId = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return favorite;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
