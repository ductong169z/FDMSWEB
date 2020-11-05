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
        /// Get all genres from database
        /// </summary>
        /// <returns>A list of all genres available</returns>
        public List<Genre> GetAllGenres()
        {
            /* Declare resources used for interacting with database */
            MySqlConnection conn = null; // connection to database
            MySqlCommand cmd; // store SQL statement
            MySqlDataReader rd = null; // reader for return results
            List<Genre> genreList = null; // list of all genres
            try
            {
                conn = DBUtils.GetConnection(); // get connection to database
                conn.Open(); // open the connection
                cmd = new MySqlCommand("SELECT * FROM genre WHERE deleted_at IS NULL", conn); // SQL statement
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                while (rd.Read())
                {
                    /* Temp vars to store genre properties */
                    int id = rd.GetInt32(0);
                    String name = rd.GetString(1);
                    DateTime created_at = rd.GetDateTime(2);

                    // instantiate if list has not yet been instantiated
                    if (genreList == null)
                    {
                        genreList = new List<Genre>();
                    }

                    // add new genre to list
                    genreList.Add(new Genre(id, name, created_at));
                }

                return genreList;
            }
            catch (Exception ex)
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

        /// <summary>
        /// Get all studios from database
        /// </summary>
        /// <returns>A list of all studios available</returns>
        public List<Studio> GetAllStudios()
        {
            /* Declare resources used for interacting with database */
            MySqlConnection conn = null; // connection to database
            MySqlCommand cmd; // store SQL statement
            MySqlDataReader rd = null; // reader for return results
            List<Studio> studioList = null; // list of all studios
            try
            {
                conn = DBUtils.GetConnection(); // get connection to database
                conn.Open(); // open the connection
                cmd = new MySqlCommand("SELECT * FROM studio WHERE deleted_at IS NULL", conn); // SQL statement
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                while (rd.Read())
                {
                    /* Temp vars to store studio properties */
                    int id = rd.GetInt32(0);
                    String name = rd.GetString(1);
                    DateTime created_at = rd.GetDateTime(2);

                    // instantiate if list has not yet been instantiated
                    if (studioList == null)
                    {
                        studioList = new List<Studio>();
                    }

                    // add new studio to list
                    studioList.Add(new Studio(id, name, created_at));
                }

                return studioList;
            }
            catch (Exception ex)
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

        /// <summary>
        /// Get all seasons from database
        /// </summary>
        /// <returns>A list of all seasons available</returns>
        public List<Season> GetAllSeasons()
        {
            /* Declare resources used for interacting with database */
            MySqlConnection conn = null; // connection to database
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
                    /* Temp vars to store season properties */
                    int id = rd.GetInt32(0);
                    String name = rd.GetString(1);
                    DateTime created_at = rd.GetDateTime(2);

                    // instantiate if list has not yet been instantiated
                    if (seasonList == null)
                    {
                        seasonList = new List<Season>();
                    }

                    // add new season to list
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

        /// <summary>
        /// Get all anime types from database
        /// </summary>
        /// <returns>A list of all anime types available</returns>
        public List<String> GetAllTypes()
        {
            /* Declare resources used for interacting with database */
            MySqlConnection conn = null; // connection to database
            MySqlCommand cmd; // store SQL statement
            MySqlDataReader rd = null; // reader for return results
            List<String> typeList = null; // list of all anime types
            try
            {
                conn = DBUtils.GetConnection(); // get connection to database
                conn.Open(); // open the connection
                cmd = new MySqlCommand("SELECT * FROM anime GROUP BY type", conn); // SQL statement
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                while (rd.Read())
                {
                    // instantiate if list has not yet been instantiated
                    if (typeList == null)
                    {
                        typeList = new List<String>();
                    }

                    // add anime type to list
                    typeList.Add(rd.GetString("type"));
                }

                return typeList;
            }
            catch (Exception ex)
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