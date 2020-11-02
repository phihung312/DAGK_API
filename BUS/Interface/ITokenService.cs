using BUS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS.Interface
{
    public interface ITokenService
    {
        AuthToken CreateToken(User user);
        AuthToken RefreshToken(string RefreshToken);

    }
}
