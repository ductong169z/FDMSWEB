using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    public class Genre
    {
        private int id;
        private string name;
        private DateTime created_at;

        public Genre()
        {
        }

        public Genre(int id, string name, DateTime created_at)
        {
            this.id = id;
            this.name = name;
            this.created_at = created_at;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
    }
}