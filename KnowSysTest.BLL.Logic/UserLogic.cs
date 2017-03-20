using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowSysTest.DAL.Db
{
    using KnowSysTest.BLL.Abstract;
    using KnowSysTest.DAL.Abstract;
    using KnowSysTest.Entities.Membership;

    public class UserLogic : IUserLogic
    {
        private IUserDAL DAL;

        public UserLogic(IUserDAL DAL)
        {
            if (DAL == null)
            {
                throw new ArgumentNullException("DAL", "DAL as parameter is null");
            }

            this.DAL = DAL;
        }
        public UserDTO GetUser(Guid id)
        {
            return this.DAL.Get(id);
        }

        public UserDTO GetUserByName(string userName)
        {
            return this.DAL.GetByName(userName);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return this.DAL.GetAll();
        }

        public bool CreateUser(UserDTO user)
        {
            return this.DAL.Create(user);
        }

        public bool UpdateUser(UserDTO user)
        {
            return this.DAL.Update(user);
        }

        public bool DeleteUser(Guid id)
        {
            return this.DAL.Delete(id);
        }

        public bool UserExists(string userName)
        {
            return this.DAL.UserExists(userName);
        }

        public bool SaveUser()
        {
            return this.DAL.Save();
        }
    }
}
