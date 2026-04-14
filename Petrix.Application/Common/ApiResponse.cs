namespace Petrix.Application.Common
{
    public record ApiResponse<T>(
        bool Success,
        string? Code,
        T? Data,
        string? Message
    );
}