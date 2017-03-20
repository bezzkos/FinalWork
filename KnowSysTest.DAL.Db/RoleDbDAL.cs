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

    public class RoleDbDAL : IRoleDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public RoleDTO Get(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Roles.GetById]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new RoleDTO()
                    {
                        RoleId = (Guid)reader["Id"],
                        RoleName = (string)reader["Name"]
                    };
                }

                throw new ArgumentException();
            }
        }

        public RoleDTO GetByName(string roleName)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Roles.GetByName]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Name", roleName);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new RoleDTO()
                    {
                        RoleId = (Guid)reader["Id"],
                        RoleName = (string)reader["Name"]
                    };
                }

                //throw new ArgumentException();
            }
            return null;
        }

        public IEnumerable<RoleDTO> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Roles.GetAll]",
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new RoleDTO()
                    {
                        RoleId = (Guid)reader["Id"],
                        RoleName = (string)reader["Name"]
                    };
                }

                throw new ArgumentException();
            }
        }

        public bool Update(RoleDTO role)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Roles.Update]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", role.RoleId);
                cmd.Parameters.AddWithValue("@Name", role.RoleName);
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
                    CommandText = "[Roles.Delete]",
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

        public bool Create(RoleDTO role)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Roles.Create]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", role.RoleId);
                cmd.Parameters.AddWithValue("@Name", role.RoleName);
                connection.Open();

                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool RoleExists(string roleName)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[Roles.IsExist]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Name", roleName);
                connection.Open();

                return (bool)cmd.ExecuteScalar();
            }
        }

        public bool Save()
        {
            return true;
        }
    }
}
