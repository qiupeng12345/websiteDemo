using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACA_System.Areas.UserManage.Models
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string UserAccount { get; set; }
        public string UserPassword { get; set; }
        public string UserCompany { get; set; }
        public string UserPart { get; set; }
        public string UserAuthority { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserSex { get; set; }
    }
}