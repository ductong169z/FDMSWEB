using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    /* DAO for FDMS Anime List Website */
    public class AnimeListDAO
    {
        /* Constructor */
        public AnimeListDAO()
        {
        }

        /// <summary>
        /// Get all seasons from database
        /// </summary>
        /// <returns>A list of all seasons available</returns>
        public List<Season> GetSeasons()
        {
            /* Declare resources used for interacting with database */
            MySqlConnection conn = null; // connnection to database
            MySqlCommand cmd; // store SQL statement
            MySqlDataReader rd = null; // reader for return results
            List<Season> seasonList = null; // list of all seasons
            try
            {
                conn = DBUtils.GetConnection(); // get connection to database
                conn.Open(); // open the connection
                cmd = new MySqlCommand("SELECT * FROM season WHERE deleted_at IS NULL", conn); // SQL statement
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                while (rd.Read())
                {
                    /* Temp vars to store Season properties */
                    int id = rd.GetInt32(0);
                    String name = rd.GetString(1);
                    DateTime created_at = rd.GetDateTime(2);

                    // instantiate if list has not yet been instantiated
                    if (seasonList == null)
                    {
                        seasonList = new List<Season>();
                    }

                    // add new Season to list
                    seasonList.Add(new Season(id, name, created_at));
                }

                return seasonList;
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                /* Close resources after use */
                if (conn != null)
                {
                    conn.Close();
                }

                if (rd != null)
                {
                    rd.Close();
                }
            }
        }
    }
}