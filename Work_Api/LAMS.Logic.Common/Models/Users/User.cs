
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace LAMS.Logic.Common.Models.Users
{
    /// <summary>
    /// Standart BLL level version of UserDB.
    /// </summary>
    public class User
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime Created { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual RoleBLL Role { get; set; }
    }
}
