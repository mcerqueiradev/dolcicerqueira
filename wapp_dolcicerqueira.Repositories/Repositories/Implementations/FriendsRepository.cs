using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class FriendsRepository : IFriendsRepository
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public Friends Add(Friends friends)
        {
            string query = "AddFriend";

            SqlParameter useroneParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserOne",
                Value = friends.UserOne
            };

            SqlParameter usertwoParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserTwo",
                Value = friends.UserTwo
            };

            SqlParameter statusParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Status",
                Value = friends.Status
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(useroneParam);
            sqlCommand.Parameters.Add(usertwoParam);
            sqlCommand.Parameters.Add(statusParam);
            _sqlConnection.Open();

            friends.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return friends;
        }

        public void Delete(int id)
        {
            string query = "DeleteFriend";

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

        public List<Friends> GetAll()
        {
            List<Friends> friendsResult = new List<Friends>();

            string query = "GetAllFriends";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                friendsResult.Add(
                    new Friends
                    {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    UserOne = Convert.ToInt32(readerTable["UserOne"]),
                    UserTwo = Convert.ToInt32(readerTable["UserTwo"]),
                    Status = Convert.ToBoolean(readerTable["Status"])
                    });
            }

            _sqlConnection.Close();

            return friendsResult;
        }

        public Friends GetById(int id)
        {
            Friends friendResult = null;

            string query = "GetFriendById";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserTwo",
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
                friendResult = new Friends
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    UserOne = Convert.ToInt32(readerTable["UserOne"]),
                    UserTwo = Convert.ToInt32(readerTable["UserTwo"]),
                    Status = Convert.ToBoolean(readerTable["Status"])
                };
            }

            _sqlConnection.Close();

            return friendResult;
        }

        public Friends GetFriendByUserIds(int userOne, int userTwo)
        {
            Friends friendResult = null;

            string query = "GetFriendByUserIds";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserOne",
                DbType = DbType.Int32,
                Value = userOne
            };

            SqlParameter searchhParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserTwo",
                DbType = DbType.Int32,
                Value = userTwo
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(searchParam);
            sqlCommand.Parameters.Add(searchhParam);

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                friendResult = new Friends
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    UserOne = Convert.ToInt32(readerTable["UserOne"]),
                    UserTwo = Convert.ToInt32(readerTable["UserTwo"]),
                    Status = Convert.ToBoolean(readerTable["Status"])
                };
            }

            _sqlConnection.Close();

            return friendResult;
        }

        public List<Friends> GetFriendsByUserId(int id)
        {
            List<Friends> friendsResult = null;

            string query = "GetFriendUserById";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserTwo",
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
                friendsResult.Add(
                    new Friends
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        UserOne = Convert.ToInt32(readerTable["UserOne"]),
                        UserTwo = Convert.ToInt32(readerTable["UserTwo"]),
                        Status = Convert.ToBoolean(readerTable["Status"])
                    });
            }

            _sqlConnection.Close();

            Friends friendship = friendsResult.FirstOrDefault(a => a.UserOne == id || a.UserTwo == id);

            return friendsResult;
        }

        public Friends Update(Friends friends)
        {
            string query = "UpdateFriend";

            SqlParameter useroneParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserOne",
                Value = friends.UserOne
            };

            SqlParameter usertwoParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UserTwo",
                Value = friends.UserTwo
            };

            SqlParameter statusParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Status",
                Value = friends.Status
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(useroneParam);
            sqlCommand.Parameters.Add(usertwoParam);
            sqlCommand.Parameters.Add(statusParam);
            _sqlConnection.Open();

            friends.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return friends;
        }
    }
}
