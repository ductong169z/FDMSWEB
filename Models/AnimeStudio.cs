using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    public class AnimeStudio
    {
        private int animeId;
        private int studioId;

        public AnimeStudio()
        {
        }

        public AnimeStudio(int animeId, int studioId)
        {
            this.animeId = animeId;
            this.studioId = studioId;
        }

        public int AnimeId { get => animeId; set => animeId = value; }
        public int StudioId { get => studioId; set => studioId = value; }
    }
}