
using System.Data.SqlClient;

namespace Alligator.DataLayer.Repositories
{
    public abstract class BaseRepository
    {
        private const string _connection = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";

        public static SqlConnection ProvideConnection() => new SqlConnection(_connection);

        protected enum AffectedRows
        {
            Zero,
            One
        }
    }
}