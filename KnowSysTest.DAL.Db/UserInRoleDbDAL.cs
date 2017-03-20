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

    public class UserInRoleDbDAL : IUserInRoleDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public UserInRoleDTO Get(Guid userId, Guid roleId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[RolesUsers.GetById]",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@RoleId", roleId);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new UserInRoleDTO()
                    {
                        UserFk = (Guid)reader["UserId"],
                        RoleFk = (Guid)reader["RoleId"]
                    };
                }

                throw new ArgumentException();
            }
        }

        public IEnumerable<UserInRoleDTO> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[RolesUsers.GetAll]",
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new UserInRoleDTO()
                    {
                        UserFk = (Guid)reader["UserId"],
                        RoleFk = (Guid)reader["RoleId"]
                    };
                }
            }
        }

        public bool Update(UserInRoleDTO userInRole)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[RolesUsers.Update]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", userInRole.UserFk);
                cmd.Parameters.AddWithValue("@RoleId", userInRole.RoleFk);
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

        public bool Delete(Guid userId, Guid roleId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[RolesUsers.Delete]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@RoleId", roleId);
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

        public bool Create(UserInRoleDTO userInRole)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "[RolesUsers.Create]",
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", userInRole.UserFk);
                cmd.Parameters.AddWithValue("@RoleId", userInRole.RoleFk);
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
