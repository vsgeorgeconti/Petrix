using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petrix.Application.Common
{
    public record ApiResponse<T>(
        bool Success,
        T? Data,
        string? Message
    );
}