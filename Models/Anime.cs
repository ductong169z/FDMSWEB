using System;
using System.Collections.Generic;

namespace FDMSWeb.Models
{
    /* DTO for Anime table */
    public class Anime
    {
        /* Anime properties */
        private int id;
        private Season season;
        private List<Studio> studios;
        private List<Genre> genres;
        private string type;
        private string name;
        private string releaseDate;
        private string rating;
        private int episodes;
        private string status;
        private string duration;
        private string description;
        private string poster;
        private string trailer;
        private string created_at;

        /* Constructors */
        public Anime()
        {
        }

        public Anime(int id, Season season, List<Studio> studios, List<Genre> genres, string type, string name, string releaseDate, string rating, int episodes, string status, string duration, string description, string poster, string trailer, string created_at)
        {
            this.id = id;
            this.season = season;
            this.studios = studios;
            this.genres = genres;
            this.type = type;
            this.name = name;
            this.releaseDate = releaseDate;
            this.rating = rating;
            this.episodes = episodes;
            this.status = status;
            this.duration = duration;
            this.description = description;
            this.poster = poster;
            this.trailer = trailer;
            this.created_at = created_at;
        }

        /* Getters and Setters */
        public int Id { get => id; set => id = value; }
        public Season Season { get => season; set => season = value; }
        public List<Studio> Studios { get => studios; set => studios = value; }
        public List<Genre> Genres { get => genres; set => genres = value; }
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public string ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public string Rating { get => rating; set => rating = value; }
        public int Episodes { get => episodes; set => episodes = value; }
        public string Status { get => status; set => status = value; }
        public string Duration { get => duration; set => duration = value; }
        public string Description { get => description; set => description = value; }
        public string Poster { get => poster; set => poster = value; }
        public string Trailer { get => trailer; set => trailer = value; }
        public string Created_at { get => created_at; set => created_at = value; }
    }
}