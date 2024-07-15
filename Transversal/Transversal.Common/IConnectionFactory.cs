using System.Data.SqlClient;

namespace Transversal.Common;

// Defines the contract for the connection repository in the transversal layer of the workspace.
public interface IConnectionFactory
{
    SqlConnection GetSqlConnection { get; }
}
