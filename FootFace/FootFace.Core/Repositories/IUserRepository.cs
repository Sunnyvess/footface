using FootFace.Core.Entities;

namespace FootFace.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User Add(User entity, string password);

        bool ChangePassword(int userId, string newPassword);

        bool ChangePassword(int userId, string oldPassword, string newPassword);

        bool UserExists(string userName, string password);

        User FindByUserName(string userName);
       
    }
}
