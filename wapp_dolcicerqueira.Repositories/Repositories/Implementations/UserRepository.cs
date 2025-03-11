using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public Users Add(Users user)
        {
            string query = "AddUser";

            SqlParameter nameParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Username",
                Value = user.Username
            };

            SqlParameter emailParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Email",
                Value = user.Email
            };

            SqlParameter passwordParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Password",
                Value = user.Password
            };

            SqlParameter blockParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserBlocked",
                Value = user.UserBlocked
            };

            SqlParameter adminParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserAdmin",
                Value = user.UserAdmin
            };

            SqlParameter imageParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ImageUrl",
                Value = user.ImageUrl
            };


            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(nameParam);
            sqlCommand.Parameters.Add(emailParam);
            sqlCommand.Parameters.Add(passwordParam);
            sqlCommand.Parameters.Add(blockParam);
            sqlCommand.Parameters.Add(adminParam);
            sqlCommand.Parameters.Add(imageParam);
            _sqlConnection.Open();

            user.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return user;
        }

        public void Delete(int id)
        {
            string query = "DeleteUser";

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

        public List<Users> GetAll()
        {
            List<Users> usersResult = new List<Users>();

            string query = "GetAllUsers";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                usersResult.Add(
                    new Users
                    {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Username = Convert.ToString(readerTable["Username"]),
                    Email = Convert.ToString(readerTable["Email"]),
                    Password = Convert.ToString(readerTable["Password"]),
                    UserBlocked = Convert.ToBoolean(readerTable["UserBlocked"]),
                    UserAdmin = Convert.ToBoolean(readerTable["UserAdmin"]),
                    ImageUrl = Convert.ToString(readerTable["ImageUrl"])
                    });
            }

            _sqlConnection.Close();

            return usersResult;
        }

        public Users GetById(int id)
        {
            Users userResult = null;

            string query = "GetUserById";

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
                userResult = new Users
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Username = Convert.ToString(readerTable["Username"]),
                    Email = Convert.ToString(readerTable["Email"]),
                    Password = Convert.ToString(readerTable["Password"]),
                    UserBlocked = Convert.ToBoolean(readerTable["UserBlocked"]),
                    UserAdmin = Convert.ToBoolean(readerTable["UserAdmin"]),
                    ImageUrl = Convert.ToString(readerTable["ImageUrl"])
                };
            }

            _sqlConnection.Close();

            return userResult;
        }

        public List<Users> GetUserList(int id)
        {
            List<Users> userResult = null;

            string query = "GetUserById";

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
                userResult.Add(
                    new Users
                    {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Username = Convert.ToString(readerTable["Username"]),
                    Email = Convert.ToString(readerTable["Email"]),
                    Password = Convert.ToString(readerTable["Password"]),
                    UserBlocked = Convert.ToBoolean(readerTable["UserBlocked"]),
                    UserAdmin = Convert.ToBoolean(readerTable["UserAdmin"]),
                    ImageUrl = Convert.ToString(readerTable["ImageUrl"])
                    });
            }

            _sqlConnection.Close();

            return userResult;
        }

        public Users GetUserLogin(string email, string password)
        {
            Users userResult = null;

            string query = "GetUserLogin";

            SqlParameter emailParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Email",
                DbType = DbType.String,
                Value = email
            };

            SqlParameter passwordParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Password",
                DbType = DbType.String,
                Value = password
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(emailParam);
            sqlCommand.Parameters.Add(passwordParam);

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                userResult = new Users
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Username = Convert.ToString(readerTable["Username"]),
                    Email = Convert.ToString(readerTable["Email"]),
                    Password = Convert.ToString(readerTable["Password"]),
                    UserBlocked = Convert.ToBoolean(readerTable["UserBlocked"]),
                    UserAdmin = Convert.ToBoolean(readerTable["UserAdmin"]),
                    ImageUrl = Convert.ToString(readerTable["ImageUrl"])
                };
            }

            _sqlConnection.Close();

            return userResult;
        }

        public Users Update(Users user)
        {
            string query = "UpdateUser";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = user.Id
            };

            SqlParameter nameParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Username",
                Value = user.Username
            };

            SqlParameter emailParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Email",
                Value = user.Email
            };

            SqlParameter passwordParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Password",
                Value = user.Password
            };

            SqlParameter blockParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserBlocked",
                Value = user.UserBlocked
            };

            SqlParameter adminParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserAdmin",
                Value = user.UserAdmin
            };

            SqlParameter imageParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ImageUrl",
                Value = user.ImageUrl
            };


            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(nameParam);
            sqlCommand.Parameters.Add(emailParam);
            sqlCommand.Parameters.Add(passwordParam);
            sqlCommand.Parameters.Add(blockParam);
            sqlCommand.Parameters.Add(adminParam);
            sqlCommand.Parameters.Add(imageParam);
            _sqlConnection.Open();

            user.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return user;
        }
    }
}
