using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petrix.Application.DTOs.Customer
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }

    }
}