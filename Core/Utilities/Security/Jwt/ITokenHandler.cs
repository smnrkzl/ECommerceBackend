using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHandler
    {
        Token CreateToken(User user);
    }
}
