using System;
using System.Linq;
using System.Transactions;
using OKU.Core.Entities;
using OKU.Core.Infrastructure.Extensions;

namespace OKU.Core.Repositories.Implementation
{
    public class UserRepository : RepositoryBase<OkuDbContext, User>, IUserRepository
    {
        public UserRepository()
        {
            this.Initialize(x => x.Users);
        }

        #region Implementation of IUserRepository

        public User Add(User entity, string password)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            entity.Password = password;
            return base.Add(entity);
        }

        public bool ChangePassword(int userId, string newPassword)
        {
            if (newPassword == null)
            {
                throw new ArgumentNullException("newPassword");
            }

            using (var scope = new TransactionScope())
            {
                using (var dbContext = RepositoryBase<OkuDbContext, User>.CreateDbContext())
                {
                    var person = dbContext.Users.Find(userId);
                    if (person == null)
                    {
                        return false;
                    }

                    person.Password = newPassword;

                    dbContext.SaveChanges();
                    scope.Complete();
                }
            }

            return true;
        }

        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            if (oldPassword == null)
            {
                throw new ArgumentNullException("oldPassword");
            }

            if (newPassword == null)
            {
                throw new ArgumentNullException("newPassword");
            }

            using (var scope = new TransactionScope())
            {
                using (var dbContext = RepositoryBase<OkuDbContext, User>.CreateDbContext())
                {
                    var person = dbContext.Users.SingleOrDefault(x => x.Id == userId && x.Password == oldPassword);
                    if (person == null)
                    {
                        return false;
                    }

                    person.Password = newPassword;

                    dbContext.SaveChanges();
                    scope.Complete();
                }
            }
            return true;
        }

        public bool UserExists(string userName, string password)
        {         
            return this.Query.Count(x => x.UserName == userName && x.Password == password) > 0;
        }

        public User FindByUserName(string userName)
        {
            return this.Query.Where(x => x.UserName == userName).SingleOrDefault();
        }

        #endregion


        public string[] GetRolesForUser(string userName, int iterationId)
        {
            // TODO - refactor to use iteration - add table userProjectRole 
            var user = FindByUserName(userName);
            UserProject userProject = this.DbContext.UserProjects.Where(x => x.UserId == user.Id && x.IterationId == iterationId).FirstOrDefault();
            if (userProject == null)
            {
                return new string[] { String.Empty };
            }
            else
            {
                var role = this.DbContext.Roles.Where(x => x.Id == userProject.RoleId).FirstOrDefault();
                return new string[] { role.Name };
            }
        }
    }
}
