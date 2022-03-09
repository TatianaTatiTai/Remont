using LAMS.DataAccess.Common.Models.Work;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Users
{
    /// <summary>
    /// DataBase entity of user.
    /// </summary>
    public class UserDb
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Created { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string RoleId { get; set; }
        public virtual RoleDb Role { get; set; }


        public virtual ICollection<OrderDb> Orders { get; set; }
    }
}
