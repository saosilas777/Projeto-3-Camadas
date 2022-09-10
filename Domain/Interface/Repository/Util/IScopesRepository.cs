using Domain.Entity.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository.Util
{
    public interface IScopesRepository
    {
        Task Add(Scopes scopes);
    }
}
