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

    public class QuestionDbDAL : IQuestionDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public QuestionDTO Get(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Questions.GetById]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new QuestionDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Question = (string)reader["Question"],
                        IsActive = (bool)reader["IsActive"],
                        IsRequired = (bool)reader["IsRequired"],
                        IsMultiple = (bool)reader["IsMultiple"],
                        TestFk = (Guid)reader["TestFk"]
                    };
                }

                throw new ArgumentException();
            }
        }

        public IEnumerable<QuestionDTO> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Questions.GetAll]",
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new QuestionDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Question = (string)reader["Question"],
                        IsActive = (bool)reader["IsActive"],
                        IsRequired = (bool)reader["IsRequired"],
                        IsMultiple = (bool)reader["IsMultiple"],
                        TestFk = (Guid)reader["TestFk"]
                    };
                }
            }
        }

        public IEnumerable<QuestionDTO> GetAllByFk(Guid fk)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Questions.GetAllByFk]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Fk", fk);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new QuestionDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Question = (string)reader["Question"],
                        IsActive = (bool)reader["IsActive"],
                        IsRequired = (bool)reader["IsRequired"],
                        IsMultiple = (bool)reader["IsMultiple"],
                        TestFk = (Guid)reader["TestFk"]
                    };
                }
            }
        }

        public bool Update(QuestionDTO question)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Questions.Update]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", question.Id);
                cmd.Parameters.AddWithValue("@Question", question.Question);
                cmd.Parameters.AddWithValue("@IsActive", question.IsActive);
                cmd.Parameters.AddWithValue("@IsRequired", question.IsRequired);
                cmd.Parameters.AddWithValue("@IsMultiple", question.IsMultiple);
                cmd.Parameters.AddWithValue("@TestFk", question.TestFk);
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
                    CommandText = "[Questions.Delete]",
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

        public bool Create(QuestionDTO question)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Questions.Create]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", question.Id);
                cmd.Parameters.AddWithValue("@Question", question.Question);
                cmd.Parameters.AddWithValue("@IsActive", question.IsActive);
                cmd.Parameters.AddWithValue("@IsRequired", question.IsRequired);
                cmd.Parameters.AddWithValue("@IsMultiple", question.IsMultiple);
                cmd.Parameters.AddWithValue("@TestFk", question.TestFk);
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
