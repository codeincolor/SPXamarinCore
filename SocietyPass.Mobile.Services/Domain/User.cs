using System;
using System.Collections.Generic;
using System.Text;
using SocietyPass.Mobile.Services.Contracts.Domain;

namespace SocietyPass.Mobile.Services.Domain
{
    public class User : BaseEntity, IUser
    {
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}
