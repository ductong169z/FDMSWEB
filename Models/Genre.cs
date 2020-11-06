using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    /* DTO for Genre table */
    public class Genre
    {
        /* Genre properties */
        private int id;
        private string name;
        private string created_at;

        /* Constructors */
        public Genre()
        {
        }

        public Genre(int id, string name, string created_at)
        {
            this.id = id;
            this.name = name;
            this.created_at = created_at;
        }

        /* Getters and Setters */
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Created_at { get => created_at; set => created_at = value; }
    }
}