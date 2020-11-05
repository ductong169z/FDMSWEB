using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    /* DTO for Anime_Studio table */
    public class AnimeStudio
    {
        /* Anime_Studio properties */
        private int animeId;
        private int studioId;

        /* Constructors */
        public AnimeStudio()
        {
        }

        public AnimeStudio(int animeId, int studioId)
        {
            this.animeId = animeId;
            this.studioId = studioId;
        }

        /* Getters and Setters */
        public int AnimeId { get => animeId; set => animeId = value; }
        public int StudioId { get => studioId; set => studioId = value; }
    }
}