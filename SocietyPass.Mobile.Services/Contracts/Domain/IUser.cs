using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyPass.Mobile.Services.Contracts.Domain
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string LoginName { get; set; }
        string Password { get; set; }
    }
}
