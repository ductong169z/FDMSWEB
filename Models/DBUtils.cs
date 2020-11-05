using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    public class DBUtils
    {
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=anime;Port=3306;User ID=root;Password=");

            return conn;
        }
    }
}