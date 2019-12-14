using Saitynas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynas.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<TblUser> WithoutPasswords(this IEnumerable<TblUser> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static TblUser WithoutPassword(this TblUser user)
        {
            user.Password = null;
            return user;
        }
    }
}
