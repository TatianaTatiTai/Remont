using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Users
{
    public class RoleDb
    {
        public string Id { get; set; }

        public string RoleName { get; set; }



        public virtual ICollection<UserDb> Users { get; set; }

    }
}
