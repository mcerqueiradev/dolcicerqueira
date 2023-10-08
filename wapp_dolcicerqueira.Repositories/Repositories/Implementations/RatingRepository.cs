using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class RatingRepository : IRatingRepository 
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public Rating Add(Rating rating)
        {
            string query = "AddRating";

            SqlParameter RatingsParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Ratings",
                Value = rating.Ratings
            };

            SqlParameter commentParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Comment",
                Value = rating.Comment
            };

            SqlParameter authorParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@AuthorId",
                Value = rating.AuthorId
            };

            SqlParameter recipeParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RecipeId",
                Value = rating.RecipeId
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(commentParam);
            sqlCommand.Parameters.Add(RatingsParam);
            sqlCommand.Parameters.Add(authorParam);
            sqlCommand.Parameters.Add(recipeParam);

            _sqlConnection.Open();

            rating.RatingId = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return rating;
        }

        public void Delete(int id)
        {
            string query = "DeleteRating";

            SqlParameter idParam = new()
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

            sqlCommand.Parameters.Add(idParam);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public Rating Update(Rating rating)
        {
            string query = "UpdateRating";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RatingId",
                DbType = DbType.Int32,
                Value = rating.RatingId
            };

            SqlParameter RatingsParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Ratings",
                Value = rating.Ratings
            };

            SqlParameter commentParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Comment",
                Value = rating.Comment
            };

            SqlParameter authorParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@AuthorId",
                Value = rating.AuthorId
            };

            SqlParameter recipeParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RecipeId",
                Value = rating.RecipeId
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(commentParam);
            sqlCommand.Parameters.Add(RatingsParam);
            sqlCommand.Parameters.Add(authorParam);
            sqlCommand.Parameters.Add(recipeParam);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

            return rating;
        }

        public Rating GetById(int id)
        {
            Rating ratingResult = null;

            string query = "GetRatingByID";

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
                ratingResult = new Rating
                {
                    RatingId = Convert.ToInt32(readerTable["RatingId"]),
                    Ratings = Convert.ToInt32(readerTable["Ratings"]),
                    Comment = Convert.ToString(readerTable["Comment"]),
                    AuthorId = Convert.ToInt32(readerTable["AuthorId"]),
                    RecipeId = Convert.ToInt32(readerTable["RecipeId"])
                };
            }

            _sqlConnection.Close();

            return ratingResult;
        }

        public List<Rating> GetByIdRecipe(int id)
        {
            List<Rating> ratingResult = new List<Rating>();

            string query = "GetRatingByIdRecipe";

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
                ratingResult.Add(
                 new Rating
                 {
                     RatingId = Convert.ToInt32(readerTable["RatingID"]),
                     Ratings = Convert.ToInt32(readerTable["Ratings"]),
                     Comment = Convert.ToString(readerTable["Comment"]),
                     AuthorId = Convert.ToInt32(readerTable["AuthorId"]),
                     RecipeId = Convert.ToInt32(readerTable["RecipeId"])
                 });
            }

            _sqlConnection.Close();

            return ratingResult;
        }

        public List<Rating> GetAll()
        {
            List<Rating> ratingsResult = new List<Rating>();

            string query = "GetAllRatings";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                ratingsResult.Add(
                    new Rating
                    {
                        RatingId = Convert.ToInt32(readerTable["RatingId"]),
                        Ratings = Convert.ToInt32(readerTable["Ratings"]),
                        RecipeId = Convert.ToInt32(readerTable["RecipeId"]),
                        Comment = Convert.ToString(readerTable["Comment"]),
                        AuthorId = Convert.ToInt32(readerTable["AuthorId"]),
                    });
            }

            _sqlConnection.Close();

            return ratingsResult;
        }

    }
}
