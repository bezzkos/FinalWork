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

    public class AnswerDbDAL : IAnswerDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public AnswerDTO Get(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Answers.GetById]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new AnswerDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Answer = (string)reader["Answer"],
                        IsCorrect = (bool)reader["IsCorrect"],
                        QuestionFk = (Guid)reader["QuestionFk"]
                    };
                }

                throw new ArgumentException();
            }
        }

        public IEnumerable<AnswerDTO> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Answers.GetAll]",
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new AnswerDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Answer = (string)reader["Answer"],
                        IsCorrect = (bool)reader["IsCorrect"],
                        QuestionFk = (Guid)reader["QuestionFk"]
                    };
                }
            }
        }

        public IEnumerable<AnswerDTO> GetAllByFk(Guid fk)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Answers.GetAllByFk]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Fk", fk);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new AnswerDTO()
                    {
                        Id = (Guid)reader["Id"],
                        Answer = (string)reader["Answer"],
                        IsCorrect = (bool)reader["IsCorrect"],
                        QuestionFk = (Guid)reader["QuestionFk"]
                    };
                }
            }
        }

        public bool Update(AnswerDTO answer)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Answers.Update]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", answer.Id);
                cmd.Parameters.AddWithValue("@Answer", answer.Answer);
                cmd.Parameters.AddWithValue("@IsCorrect", answer.IsCorrect);
                cmd.Parameters.AddWithValue("@QuestionFk", answer.QuestionFk);
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
                    CommandText = "[Answers.Delete]",
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

        public bool Create(AnswerDTO answer)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Answers.Create]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", answer.Id);
                cmd.Parameters.AddWithValue("@Answer", answer.Answer);
                cmd.Parameters.AddWithValue("@IsCorrect", answer.IsCorrect);
                cmd.Parameters.AddWithValue("@QuestionFk", answer.QuestionFk);
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
