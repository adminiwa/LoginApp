using LoginApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Core.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(UserModel user);
    }
}
