using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    /* Establishment of connection to database */
    public class DBUtils
    {
        /// <summary>
        /// Get connection to database 
        /// </summary>
        /// <returns>A connection to database if successful, null if failed</returns>
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=anime;Port=3306;User ID=root;Password=");

            return conn;
        }
    }
}