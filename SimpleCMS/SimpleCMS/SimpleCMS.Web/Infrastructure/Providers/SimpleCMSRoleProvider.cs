using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web;
using System.Linq;
using System.Text;
using SimpleCMS.Core.Repositories;
using Ninject;
using System.Web.Mvc;

namespace SimpleCMS.Web.Infrastructure.Providers
{
    public class SimpleCMSRoleProvider : RoleProvider
    {    
        public override string[] GetRolesForUser(string username)
        {
            //TODO : iteration support, refactor use of dependencyResolver         
            return DependencyResolver.Current.GetService<IUserRepository>().GetRolesForUser(username, 1);
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }

}
