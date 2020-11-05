using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    /* DTO for Season table */
    public class Season
    {
        /* Season properties */
        private int id;
        private string name;
        private DateTime created_at;

        /* Constructors */
        public Season()
        {
        }

        public Season(int id, string name, DateTime created_at)
        {
            this.id = id;
            this.name = name;
            this.created_at = created_at;
        }

        /* Getters and Setters */
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
    }
}