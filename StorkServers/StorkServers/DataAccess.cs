using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace StorkServers
{
    public class DataAccess
    {
        string connString = Helper.CnnVal("Docker-Image");
        //string connString = Helper.CnnVal("Keith-PC");

        public List<Server> GetServers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connString))
            {
                return connection.Query<Server>($"SELECT * FROM Server_Names").ToList();
            }
        }

        public List<Location> GetLocations()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connString))
            {
                return connection.Query<Location>($"SELECT * FROM Locations").ToList();
            }
        }
    }
}
