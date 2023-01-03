﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<String> Claims(this ClaimsPrincipal claimsPrincipal,string claimType)
        {
            var result = claimsPrincipal.FindAll(claimType)?.Select(p => p.Value).ToList();
            return result;
        }
    }
}
