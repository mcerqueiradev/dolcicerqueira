using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class RecipeRepository : IRecipeRepository
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public Recipe Add(Recipe recipe)
        {
            string query = "AddRecipe";

            SqlParameter titleParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Title",
                Value = recipe.Title
            };

            SqlParameter descriptionParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Description",
                Value = recipe.Description
            };

            SqlParameter authorParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@AuthorId",
                Value = recipe.AuthorId
            };

            SqlParameter dataParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Data",
                Value = recipe.Data
            };

            SqlParameter categoryParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CategoryId",
                Value = recipe.CategoryId
            };

            SqlParameter ratingParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RatingId",
                Value = recipe.RatingId
            };

            SqlParameter timeParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@PreparationTime",
                Value = recipe.PreparationTime
            };

            SqlParameter portionsParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Portions",
                Value = recipe.Portions
            };

            SqlParameter imageParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ImageUrl",
                Value = recipe.ImageUrl
            };

            SqlParameter statusParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IsApproved",
                Value = recipe.IsApproved
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(titleParam);
            sqlCommand.Parameters.Add(descriptionParam);
            sqlCommand.Parameters.Add(authorParam);
            sqlCommand.Parameters.Add(dataParam);
            sqlCommand.Parameters.Add(categoryParam);
            sqlCommand.Parameters.Add(ratingParam);
            sqlCommand.Parameters.Add(timeParam);
            sqlCommand.Parameters.Add(portionsParam);
            sqlCommand.Parameters.Add(imageParam);
            sqlCommand.Parameters.Add(statusParam);

            _sqlConnection.Open();

            recipe.Id = Convert.ToInt32(sqlCommand.ExecuteScalar());

            _sqlConnection.Close();

            return recipe;
        }

        public void Delete(int id)
        {
            string query = "DeleteRecipe";

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

        public List<Recipe> GetAll()
        {
            List<Recipe> recipesResult = new List<Recipe>();

            string query = "GetAllRecipes";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                recipesResult.Add(
                    new Recipe
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        Title = Convert.ToString(readerTable["Title"]),
                        Description = Convert.ToString(readerTable["Description"]),
                        AuthorId = Convert.ToInt32(readerTable["AuthorId"]),
                        Data = Convert.ToDateTime(readerTable["Data"]),
                        CategoryId = Convert.ToInt32(readerTable["CategoryId"]),
                        RatingId = Convert.ToInt32(readerTable["RatingId"]),
                        Portions = Convert.ToInt32(readerTable["Portions"]),
                        PreparationTime = Convert.ToDateTime(readerTable["PreparationTime"]),
                        ImageUrl = Convert.ToString(readerTable["ImageUrl"]),
                        IsApproved = Convert.ToBoolean(readerTable["IsApproved"])
                    });
            }

            _sqlConnection.Close();

            return recipesResult;
        }

        public List<Recipe> RecipesApproved()
        {
            List<Recipe> recipesResult = new List<Recipe>();

            string query = "RecipesApproved";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                recipesResult.Add(
                    new Recipe
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        Title = Convert.ToString(readerTable["Title"]),
                        Description = Convert.ToString(readerTable["Description"]),
                        AuthorId = Convert.ToInt32(readerTable["AuthorId"]),
                        Data = Convert.ToDateTime(readerTable["Data"]),
                        CategoryId = Convert.ToInt32(readerTable["CategoryId"]),
                        RatingId = Convert.ToInt32(readerTable["RatingId"]),
                        Portions = Convert.ToInt32(readerTable["Portions"]),
                        PreparationTime = Convert.ToDateTime(readerTable["PreparationTime"]),
                        ImageUrl = Convert.ToString(readerTable["ImageUrl"]),
                        IsApproved = Convert.ToBoolean(readerTable["IsApproved"])
                    });
            }

            _sqlConnection.Close();

            return recipesResult;
        }

        public List<Recipe> RecipesApprovedById()
        {
            List<Recipe> recipesResult = new List<Recipe>();

            string query = "RecipesApprovedById";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();


            while (readerTable.Read())
            {
                recipesResult.Add(
                    new Recipe
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        Title = Convert.ToString(readerTable["Title"]),
                        Description = Convert.ToString(readerTable["Description"]),
                        AuthorId = Convert.ToInt32(readerTable["AuthorId"]),
                        Data = Convert.ToDateTime(readerTable["Data"]),
                        CategoryId = Convert.ToInt32(readerTable["CategoryId"]),
                        RatingId = Convert.ToInt32(readerTable["RatingId"]),
                        Portions = Convert.ToInt32(readerTable["Portions"]),
                        PreparationTime = Convert.ToDateTime(readerTable["PreparationTime"]),
                        ImageUrl = Convert.ToString(readerTable["ImageUrl"]),
                        IsApproved = Convert.ToBoolean(readerTable["IsApproved"])
                    });
            }

            _sqlConnection.Close();

            return recipesResult;
        }

        public List<Recipe> RecipesUnapproved()
        {
            List<Recipe> recipesResult = new List<Recipe>();

            string query = "RecipesUnapproved";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                recipesResult.Add(
                    new Recipe
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        Title = Convert.ToString(readerTable["Title"]),
                        Description = Convert.ToString(readerTable["Description"]),
                        AuthorId = Convert.ToInt32(readerTable["AuthorId"]),
                        Data = Convert.ToDateTime(readerTable["Data"]),
                        CategoryId = Convert.ToInt32(readerTable["CategoryId"]),
                        RatingId = Convert.ToInt32(readerTable["RatingId"]),
                        Portions = Convert.ToInt32(readerTable["Portions"]),
                        PreparationTime = Convert.ToDateTime(readerTable["PreparationTime"]),
                        ImageUrl = Convert.ToString(readerTable["ImageUrl"]),
                        IsApproved = Convert.ToBoolean(readerTable["IsApproved"])
                    });
            }

            _sqlConnection.Close();

            return recipesResult;
        }

        public Recipe GetById(int id)
        {
            Recipe recipeResult = null;

            string query = "GetRecipeById";

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
                recipeResult = new Recipe
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Title = Convert.ToString(readerTable["Title"]),
                    Description = Convert.ToString(readerTable["Description"]),
                    AuthorId = Convert.ToInt32(readerTable["AuthorId"]),
                    Data = Convert.ToDateTime(readerTable["Data"]),
                    CategoryId = Convert.ToInt32(readerTable["CategoryId"]),
                    RatingId = Convert.ToInt32(readerTable["RatingId"]),
                    Portions = Convert.ToInt32(readerTable["Portions"]),
                    PreparationTime = Convert.ToDateTime(readerTable["PreparationTime"]),
                    ImageUrl = Convert.ToString(readerTable["ImageUrl"]),
                    IsApproved = Convert.ToBoolean(readerTable["IsApproved"])

                };
            }

            _sqlConnection.Close();

            return recipeResult;
        }

        public Recipe Update(Recipe recipe)
        {
            string query = "UpdateRecipe";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
                Value = recipe.Id
            };
            SqlParameter titleParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Title",
                Value = recipe.Title
            };

            SqlParameter descriptionParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Description",
                Value = recipe.Description
            };

            SqlParameter dataParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Data",
                Value = recipe.Data
            };

            SqlParameter authorParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@AuthorId",
                Value = recipe.AuthorId
            };

            SqlParameter categoryParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CategoryId",
                Value = recipe.CategoryId
            };

            SqlParameter ratingParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RatingId",
                Value = recipe.RatingId
            };

            SqlParameter timeParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@PreparationTime",
                Value = recipe.PreparationTime
            };

            SqlParameter portionsParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Portions",
                Value = recipe.Portions
            };

            SqlParameter imageParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ImageUrl",
                Value = recipe.ImageUrl
            };

            SqlParameter statusParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IsApproved",
                Value = recipe.IsApproved
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(titleParam);
            sqlCommand.Parameters.Add(descriptionParam);
            sqlCommand.Parameters.Add(authorParam);
            sqlCommand.Parameters.Add(dataParam);
            sqlCommand.Parameters.Add(categoryParam);
            sqlCommand.Parameters.Add(ratingParam);
            sqlCommand.Parameters.Add(timeParam);
            sqlCommand.Parameters.Add(portionsParam);
            sqlCommand.Parameters.Add(imageParam);
            sqlCommand.Parameters.Add(statusParam);

            _sqlConnection.Open();

            recipe.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return recipe;
        }

        public Recipe LastRecipe()
        {
            Recipe recipeResult = null;

            string query = "LastRecipe";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                recipeResult = new Recipe
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Title = Convert.ToString(readerTable["Title"]),
                    Description = Convert.ToString(readerTable["Description"]),
                    AuthorId = Convert.ToInt32(readerTable["AuthorId"]),
                    Data = Convert.ToDateTime(readerTable["Data"]),
                    CategoryId = Convert.ToInt32(readerTable["CategoryId"]),
                    RatingId = Convert.ToInt32(readerTable["RatingId"]),
                    Portions = Convert.ToInt32(readerTable["Portions"]),
                    PreparationTime = Convert.ToDateTime(readerTable["PreparationTime"]),
                    ImageUrl = Convert.ToString(readerTable["ImageUrl"]),
                    IsApproved = Convert.ToBoolean(readerTable["IsApproved"])
                };
            }

            _sqlConnection.Close();

            return recipeResult;
        }
    }
}
