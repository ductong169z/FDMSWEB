using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    /* DTO for Anime_Genre table */
    public class AnimeGenre
    {
        /* Anime_Genre properties */
        private int genreId;
        private int animeId;
        private DateTime created_at;

        /* Constructors */
        public AnimeGenre()
        {
        }

        public AnimeGenre(int genreId, int animeId, DateTime created_at)
        {
            this.genreId = genreId;
            this.animeId = animeId;
            this.created_at = created_at;
        }

        /* Getters and Setters */
        public int GenreId { get => genreId; set => genreId = value; }
        public int AnimeId { get => animeId; set => animeId = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
    }
}