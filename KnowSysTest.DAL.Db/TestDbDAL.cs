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

    public class TestDbDAL : ITestDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public TestDTO Get(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Tests.GetById]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new TestDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"],
                        Description = (string)reader["Description"],
                        IsActive = (bool)reader["IsActive"],
                        CategoryFk = (Guid)reader["CategoryFk"]
                    };
                }

                throw new ArgumentException();
            }
        }

        public IEnumerable<TestDTO> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Tests.GetAll]",
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new TestDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"],
                        Description = (string)reader["Description"],
                        IsActive = (bool)reader["IsActive"],
                        CategoryFk = (Guid)reader["CategoryFk"]
                    };
                }
            }
        }

        public IEnumerable<TestDTO> GetAllByFk(Guid fk)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Tests.GetAllByFk]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Fk", fk);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new TestDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"],
                        Description = (string)reader["Description"],
                        IsActive = (bool)reader["IsActive"],
                        CategoryFk = (Guid)reader["CategoryFk"]
                    };
                }
            }
        }

        public bool Update(TestDTO test)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Tests.Update]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", test.Id);
                cmd.Parameters.AddWithValue("@Title", test.Title);
                cmd.Parameters.AddWithValue("@Description", test.Description);
                cmd.Parameters.AddWithValue("@IsActive", test.IsActive);
                cmd.Parameters.AddWithValue("@CategoryFk", test.CategoryFk);
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

        public bool Delete(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Tests.Delete]",
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

        public bool Create(TestDTO test)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Tests.Create]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", test.Id);
                cmd.Parameters.AddWithValue("@Title", test.Title);
                cmd.Parameters.AddWithValue("@Description", test.Description);
                cmd.Parameters.AddWithValue("@IsActive", test.IsActive);
                cmd.Parameters.AddWithValue("@CategoryFk", test.CategoryFk);
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
