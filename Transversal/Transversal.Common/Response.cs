namespace Transversal.Common;

// Represents the response structure for client interactions in the transversal layer of the workspace.
// This class encapsulates the data, success status, and message for API responses.
public class Response<T>
{
    public T? Data { get; set; }
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
