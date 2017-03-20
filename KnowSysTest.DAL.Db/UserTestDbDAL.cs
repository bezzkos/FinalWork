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
    using KnowSysTest.Entities;
    using KnowSysTest.Entities.Membership;

    public class UserTestDbDAL : IUserTestDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public UserTestDTO Get(Guid userId, Guid testId, int attemptDateTime)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[UserTest.GetById]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@TestId", testId);
                cmd.Parameters.AddWithValue("@AttemptDateTime", attemptDateTime);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new UserTestDTO()
                    {
                        UserFk = (Guid)reader["UserId"],
                        TestFk = (Guid)reader["TestId"],
                        Mark = float.Parse(reader["Mark"].ToString()),
                        IsPassed = (bool)reader["IsPassed"],
                        AttemptDateTime = (DateTime)reader["AttemptDateTime"]
                    };
                }

                throw new ArgumentException();
            }
        }

        public IEnumerable<UserTestDTO> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[UserTest.GetAll]",
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new UserTestDTO()
                    {
                        UserFk = (Guid)reader["UserId"],
                        TestFk = (Guid)reader["TestId"],
                        Mark = float.Parse(reader["Mark"].ToString()),
                        IsPassed = (bool)reader["IsPassed"],
                        AttemptDateTime = (DateTime)reader["AttemptDateTime"]
                    };
                }
            }
        }

        public bool Update(UserTestDTO usertest)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[UserTest.Update]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", usertest.UserFk);
                cmd.Parameters.AddWithValue("@TestId", usertest.TestFk);
                cmd.Parameters.AddWithValue("@Mark", usertest.Mark);
                cmd.Parameters.AddWithValue("@IsPassed", usertest.IsPassed);
                cmd.Parameters.AddWithValue("@AttemptDateTime", usertest.AttemptDateTime);
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

        public bool Delete(Guid userId, Guid testId, int attemptDateTime)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[UserTest.Delete]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@TestId", testId);
                cmd.Parameters.AddWithValue("@AttemptDateTime", attemptDateTime);
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

        public bool Create(UserTestDTO usertest)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[UserTest.Create]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", usertest.UserFk);
                cmd.Parameters.AddWithValue("@TestId", usertest.TestFk);
                cmd.Parameters.AddWithValue("@Mark", usertest.Mark);
                cmd.Parameters.AddWithValue("@IsPassed", usertest.IsPassed);
                cmd.Parameters.AddWithValue("@AttemptDateTime", usertest.AttemptDateTime);
                connection.Open();

                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool Save()
        {
            return true;
        }
    }
}
