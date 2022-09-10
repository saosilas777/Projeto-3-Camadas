using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Configurations
{
    public interface IAggregateRoot
    {
        public Guid Id { get; }
    }
}
