﻿using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace infrastructure
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnect");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}