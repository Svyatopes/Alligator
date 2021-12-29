using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.DataLayer.Repositories
{
    public class BaseRepository
    {
        private const string _connectionString = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
        protected IDbConnection GetConnection()
        {
            IDbConnection connection= new SqlConnection(_connectionString);
            return connection;
        }

    }
}
