using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TodoApp.Data.Repositories
{
    public abstract class RepositoryBase
    {
        public RepositoryBase(IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetSection(CONNECTIONSTRING_KEY);

            if (string.IsNullOrWhiteSpace(connectionString.Value))
                throw new ArgumentNullException("Connection string not found");

            connection = new SqlConnection(connectionString.Value);
        }

        private const string CONNECTIONSTRING_KEY = "ConnectionString";

        protected SqlConnection connection;
    }
}
