using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    public class Role
    {
        private int id;
        private string slug;
        private string name;

        public Role()
        {
        }

        public Role(int id, string slug, string name)
        {
            this.id = id;
            this.slug = slug;
            this.name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Slug { get => slug; set => slug = value; }
        public string Name { get => name; set => name = value; }
    }
}