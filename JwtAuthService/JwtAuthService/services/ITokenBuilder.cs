using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthService.services
{
    public interface ITokenBuilder
    {
        string BuildToken(String username);
    }
}
