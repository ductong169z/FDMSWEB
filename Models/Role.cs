using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    /* DTO for Role table */
    public class Role
    {
        /* Role properties */
        private int id;
        private string slug;
        private string name;

        /* Constructors */
        public Role()
        {
        }

        public Role(int id, string slug, string name)
        {
            this.id = id;
            this.slug = slug;
            this.name = name;
        }

        /* Getters and Setters */
        public int Id { get => id; set => id = value; }
        public string Slug { get => slug; set => slug = value; }
        public string Name { get => name; set => name = value; }
    }
}