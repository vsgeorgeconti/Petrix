using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petrix.Domain.Enums;

namespace Petrix.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Description { get; set; } = null!;
        public AccessLevel AccessLevel {get; set;}        
        
    }
}