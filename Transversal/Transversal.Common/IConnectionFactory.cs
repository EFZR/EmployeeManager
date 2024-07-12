using System.Data.SqlClient;

namespace Transversal.Common;

public interface IConnectionFactory
{
    SqlConnection GetSqlConnection { get; }
}
