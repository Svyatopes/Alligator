﻿
using System.Data.SqlClient;

namespace Alligator.DataLayer.Repositories
{
    public static class BaseRepository
    {
        private const string _connection = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";

        public static SqlConnection GetConnection() =>  new SqlConnection(_connection);
    }
}
