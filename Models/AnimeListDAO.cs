using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    public class AnimeListDAO
    {
        public AnimeListDAO()
        {
        }

        public List<Season> GetSeasons()
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader rd = null;
            List<Season> seasonList = null;
            try
            {
                conn = DBUtils.GetConnection();
                conn.Open();
                cmd = new MySqlCommand("SELECT * FROM season WHERE deleted_at IS NULL", conn);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    int id = rd.GetInt32(0);
                    String name = rd.GetString(1);
                    DateTime created_at = rd.GetDateTime(2);

                    if (seasonList == null)
                    {
                        seasonList = new List<Season>();
                    }
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