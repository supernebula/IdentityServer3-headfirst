using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServer3.Core.Models;
using System.Threading.Tasks;

namespace WebHostIdSrv.Services
{
    static class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
        {
            new Scope
            {
                Name = "api1"
            }
        };
        }
    }
}


