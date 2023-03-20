using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Backend.Repositories
{
    public class CommanRepository
    {
        protected NpgsqlConnection cn;

        public CommanRepository()
        {
            IConfiguration myConfig = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            cn = new NpgsqlConnection(myConfig.GetConnectionString("pgconn"));
        }
    }
}