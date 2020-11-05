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
        /// Get all animes from database
        /// </summary>
        /// <returns>A list of all animes available</returns>
        public List<Anime> GetAllAnimes()
        {
            /* Declare resources used for interacting with database */
            MySqlConnection conn = null; // connection to database
            MySqlCommand cmd; // store SQL statement
            MySqlDataReader rd = null; // reader for return results
            List<Anime> animeList = null; // list of all animes
            try
            {
                conn = DBUtils.GetConnection(); // get connection to database
                conn.Open(); // open the connection
                cmd = new MySqlCommand("SELECT * FROM anime WHERE deleted_at IS NULL", conn); // SQL statement
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                while (rd.Read())
                {
                    /* Temp vars to store anime properties */
                    int id = rd.GetInt32(0);
                    Season season = GetSeason(rd.GetInt32(2));
                    List<Studio> studios = GetStudioList(id);
                    List<Genre> genres = GetGenreList(id);
                    string type = rd.GetString(3);
                    string name = rd.GetString(4);
                    string releaseDate;
                    if (!rd.IsDBNull(5))
                    {
                        releaseDate = rd.GetDateTime(5).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        releaseDate = "";
                    }
                    string rating = rd.GetString(6);
                    int episodes = rd.GetInt32(7);
                    string status = rd.GetString(8);
                    string duration = rd.GetString(9);
                    string description = rd.GetString(10);
                    string poster = rd.GetString(11);
                    string trailer = rd.GetString(12);
                    string created_at;
                    if (!rd.IsDBNull(13))
                    {
                        created_at = rd.GetDateTime(13).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        created_at = "";
                    }

                    // instantiate if list has not yet been instantiated
                    if (animeList == null)
                    {
                        animeList = new List<Anime>();
                    }

                    // add new anime to list
                    animeList.Add(new Anime(id, season, studios, genres, type, name, releaseDate, rating, episodes, status, duration, description, poster, trailer, created_at));
                }

                return animeList;
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
                    string created_at;
                    if (!rd.IsDBNull(2))
                    {
                        created_at = rd.GetDateTime(2).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        created_at = "";
                    }

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
                    string created_at;
                    if (!rd.IsDBNull(2))
                    {
                        created_at = rd.GetDateTime(2).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        created_at = "";
                    }

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
                cmd = new MySqlCommand("SELECT * FROM season WHERE deleted_at IS NULL ORDER BY SeasonID DESC", conn); // SQL statement
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                while (rd.Read())
                {
                    /* Temp vars to store season properties */
                    int id = rd.GetInt32(0);
                    String name = rd.GetString(1);
                    string created_at;
                    if (!rd.IsDBNull(2))
                    {
                        created_at = rd.GetDateTime(2).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        created_at = "";
                    }

                    // instantiate if list has not yet been instantiated
                    if (seasonList == null)
                    {
                        seasonList = new List<Season>();
                    }

                    // add new season to list
                    seasonList.Add(new Season(id, name, created_at));
                }

                return seasonList;
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
                    typeList.Add(rd.GetString(3));
                }

                return typeList;
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
        /// Get a specific season from database with its ID
        /// </summary>
        /// <returns>A specific season</returns>
        public Season GetSeason(int seasonId)
        {
            if (seasonId == 0)
            {
                return new Season(0, "", "");
            }

            /* Declare resources used for interacting with database */
            MySqlConnection conn = null; // connection to database
            MySqlCommand cmd; // store SQL statement
            MySqlDataReader rd = null; // reader for return results
            Season season = null; // the season obj to return
            try
            {
                conn = DBUtils.GetConnection(); // get connection to database
                conn.Open(); // open the connection
                cmd = new MySqlCommand("SELECT * FROM season WHERE SeasonID = @Id AND deleted_at IS NULL", conn); // SQL statement
                cmd.Parameters.AddWithValue("@Id", seasonId);
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                if (rd.Read())
                {
                    /* Temp vars to store season properties */
                    string name = rd.GetString(1);
                    string created_at;
                    if (!rd.IsDBNull(2))
                    {
                        created_at = rd.GetDateTime(2).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        created_at = "";
                    }

                    // assign a new instance with properties to the return season
                    season = new Season(seasonId, name, created_at);
                }

                // return the season obj
                return season;
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
        /// Get a list of studios of an anime with its Id
        /// </summary>
        /// <returns>A list of all studios of the anime</returns>
        public List<Studio> GetStudioList(int animeId)
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
                cmd = new MySqlCommand("SELECT * FROM anime_studio JOIN studio ON studio.StudioID = anime_studio.StudioID WHERE anime_studio.AnimeID = @Id AND studio.deleted_at IS NULL", conn); // SQL statement
                cmd.Parameters.AddWithValue("@Id", animeId);
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                while (rd.Read())
                {
                    /* Temp vars to store studio properties */
                    int id = rd.GetInt32(1);
                    String name = rd.GetString(4);
                    string created_at;
                    if (!rd.IsDBNull(5))
                    {
                        created_at = rd.GetDateTime(6).ToString("dd/MM/yyyy");
                    } else
                    {
                        created_at = "";
                    }

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
        /// Get a list of genres of an anime with its Id
        /// </summary>
        /// <returns>A list of all genres of the anime</returns>
        public List<Genre> GetGenreList(int animeId)
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
                cmd = new MySqlCommand("SELECT * FROM genre_anime JOIN genre on genre.GenreID = genre_anime.GenreID WHERE genre_anime.AnimeID = @Id AND genre.deleted_at IS NULL", conn); // SQL statement
                cmd.Parameters.AddWithValue("@Id", animeId);
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                while (rd.Read())
                {
                    /* Temp vars to store genre properties */
                    int id = rd.GetInt32(1);
                    String name = rd.GetString(5);
                    string created_at;
                    if (!rd.IsDBNull(6))
                    {
                        created_at = rd.GetDateTime(6).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        created_at = "";
                    }

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
        /// Get a specific anime from database with its ID
        /// </summary>
        /// <returns>A specific anime</returns>
        public Anime GetAnime(int animeId)
        {
            /* Declare resources used for interacting with database */
            MySqlConnection conn = null; // connection to database
            MySqlCommand cmd; // store SQL statement
            MySqlDataReader rd = null; // reader for return results
            Anime anime = null; // the anime obj to return 
            try
            {
                conn = DBUtils.GetConnection(); // get connection to database
                conn.Open(); // open the connection
                cmd = new MySqlCommand("SELECT * FROM Anime WHERE AnimeID = @Id AND deleted_at IS NULL", conn); // SQL statement
                cmd.Parameters.AddWithValue("@Id", animeId);
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                if (rd.Read())
                {
                    /* Temp vars to store anime properties */
                    Season season = GetSeason(rd.GetInt32(2));
                    List<Studio> studios = GetStudioList(animeId);
                    List<Genre> genres = GetGenreList(animeId);
                    string type = rd.GetString(3);
                    string name = rd.GetString(4);
                    string releaseDate;
                    if (!rd.IsDBNull(5))
                    {
                        releaseDate = rd.GetDateTime(5).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        releaseDate = "";
                    }
                    string rating = rd.GetString(6);
                    int episodes = rd.GetInt32(7);
                    string status = rd.GetString(8);
                    string duration = rd.GetString(9);
                    string description = rd.GetString(10);
                    string poster = rd.GetString(11);
                    string trailer = rd.GetString(12);
                    string created_at;
                    if (!rd.IsDBNull(13))
                    {
                        created_at = rd.GetDateTime(13).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        created_at = "";
                    }

                    // assign a new anime instance with properties to the return anime
                    anime = new Anime(animeId, season, studios, genres, type, name, releaseDate, rating, episodes, status, duration, description, poster, trailer, created_at);
                }

                // return the anime obj
                return anime;
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
        /// Get animes matching search criteria
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="searchType"></param>
        /// <param name="studioId"></param>
        /// <param name="genreId"></param>
        /// <param name="seasonId"></param>
        /// <returns>A list of animes matching search criteria</returns>
        public List<Anime> GetSearchAnime(string searchValue, string searchType, string studioId, string genreId, string seasonId)
        {
            /* Declare resources used for interacting with database */
            MySqlConnection conn = null; // connection to database
            MySqlCommand cmd; // store SQL statement
            MySqlDataReader rd = null; // reader for return results
            List<Anime> animeList = null; // list of animes matching search criteria
            try
            {
                conn = DBUtils.GetConnection(); // get connection to database
                conn.Open(); // open the connection
                cmd = new MySqlCommand("SELECT anime.AnimeID, anime.SeasonID, anime.name , anime.type , anime.releaseDate , anime.rating , anime.episodes , anime.status , anime.duration, anime.description, anime.poster, anime.trailer, anime.created_at, StudioID, GenreID \n"
                    + "FROM \n"
                    + "anime JOIN anime_studio ON anime.AnimeID = anime_studio.AnimeID  \n"
                    + "JOIN genre_anime ON genre_anime.AnimeID = anime.AnimeID \n"
                    + "WHERE anime.name LIKE @animename AND \n"
                    + "type LIKE @type AND \n"
                    + "GenreID LIKE @genreId AND \n"
                    + "StudioID LIKE @studioId AND \n"
                    + "(SeasonID LIKE @seasonId OR SeasonID IS NULL)\n"
                    + "GROUP BY anime.name", conn); // SQL statement
                cmd.Parameters.AddWithValue("@animename", "%" + searchValue + "%");
                cmd.Parameters.AddWithValue("@type", searchType);
                cmd.Parameters.AddWithValue("@genreId", genreId);
                cmd.Parameters.AddWithValue("@studioId", studioId);
                cmd.Parameters.AddWithValue("@seasonId", seasonId);
                rd = cmd.ExecuteReader(); // execute the SQL statement and store results to reader

                /* Keep reading and adding data to list until end */
                if (rd.Read())
                {
                    /* Temp vars to store anime properties */
                    int id = rd.GetInt32(0);
                    Season season = GetSeason(rd.GetInt32(2));
                    List<Studio> studios = GetStudioList(id);
                    List<Genre> genres = GetGenreList(id);
                    string type = rd.GetString(3);
                    string name = rd.GetString(4);
                    string releaseDate;
                    if (!rd.IsDBNull(5))
                    {
                        releaseDate = rd.GetDateTime(5).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        releaseDate = "";
                    }
                    string rating = rd.GetString(6);
                    int episodes = rd.GetInt32(7);
                    string status = rd.GetString(8);
                    string duration = rd.GetString(9);
                    string description = rd.GetString(10);
                    string poster = rd.GetString(11);
                    string trailer = rd.GetString(12);
                    string created_at;
                    if (!rd.IsDBNull(13))
                    {
                        created_at = rd.GetDateTime(13).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        created_at = "";
                    }

                    // add new anime to list
                    animeList.Add(new Anime(id, season, studios, genres, type, name, releaseDate, rating, episodes, status, duration, description, poster, trailer, created_at));
                }

                return animeList;
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