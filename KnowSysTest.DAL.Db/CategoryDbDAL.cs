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

    public class CategoryDbDAL : ICategoryDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public CategoryDTO Get(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Categories.GetById]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new CategoryDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"]
                    };
                }

                throw new ArgumentException();
            }
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Categories.GetAll]",
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new CategoryDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"]
                    };
                }
            }
        }

        public bool Update(CategoryDTO category)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Categories.Update]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", category.Id);
                cmd.Parameters.AddWithValue("@Title", category.Title);
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
                    CommandText = "[Categories.Delete]",
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

        public bool Create(CategoryDTO category)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Categories.Create]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", category.Id);
                cmd.Parameters.AddWithValue("@Title", category.Title);
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
