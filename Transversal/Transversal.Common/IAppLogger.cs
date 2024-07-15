namespace Transversal.Common;

// Defines the contract for logging operations in the transversal layer of the workspace.
// This interface specifies methods for logging informational, warning, and error messages.
public interface IAppLogger<T>
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
    void LogError(string message, params object[] args);
}
