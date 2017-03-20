using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowSysTest.DAL.Db
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    using KnowSysTest.DAL.Abstract;
    using KnowSysTest.Entities.Membership;

    public class UserDbDAL : IUserDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public UserDTO Get(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Users.GetById]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new UserDTO()
                    {
                        UserId = (Guid)reader["Id"],
                        UserName = (string)reader["UserName"],
                        Password = (string)reader["Password"],
                        Salt = (string)reader["Salt"]
                    };
                }

                throw new ArgumentException();
            }
        }

        public UserDTO GetByName(string userName)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Users.GetByName]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserName", userName);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new UserDTO()
                    {
                        UserId = (Guid)reader["Id"],
                        UserName = (string)reader["UserName"],
                        Password = (string)reader["Password"],
                        Salt = (string)reader["Salt"]
                    };
                }
                
            }
            return null;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Users.GetAll]",
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new UserDTO()
                    {
                        UserId = (Guid)reader["Id"],
                        UserName = (string)reader["UserName"],
                        Password = (string)reader["Password"],
                        Salt = (string)reader["Salt"]
                    };
                }
            }
        }

        public bool Delete(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Users.Delete]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@Count",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    });
                connection.Open();
                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["@Count"].Value == 1;
            }
        }

        public bool UserExists(string userName)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Users.IsExist]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserName", userName);
                connection.Open();

                return (bool)cmd.ExecuteScalar();
            }
        }

        public bool Save()
        {
            return true;
        }

        public bool Create(UserDTO user)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Users.Create]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", user.UserId);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Salt", user.Salt);
                connection.Open();

                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool Update(UserDTO user)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Users.Update]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", user.UserId);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Salt", user.Salt);
                cmd.Parameters.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@Count",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    });
                connection.Open();
                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["@Count"].Value == 1;
            }
        }
    }
}
