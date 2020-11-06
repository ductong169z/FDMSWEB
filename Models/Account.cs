using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    /* DTO for Account table */
    public class Account
    {
        /* Account properties */
        private int id;
        private int roleId;
        private string username;
        private string fullName;
        private string avatar;
        private string email;
        private int gender;
        private string created_at;

        /* Constructors */
        public Account()
        {
        }

        public Account(int id, int roleId, string username, string fullName, string avatar, string email, int gender, string created_at)
        {
            this.id = id;
            this.roleId = roleId;
            this.username = username;
            this.fullName = fullName;
            this.avatar = avatar;
            this.email = email;
            this.gender = gender;
            this.created_at = created_at;
        }

        /* Getters and Setters */
        public int Id { get => id; set => id = value; }
        public int RoleId { get => roleId; set => roleId = value; }
        public string Username { get => username; set => username = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public string Email { get => email; set => email = value; }
        public int Gender { get => gender; set => gender = value; }
        public string Created_at { get => created_at; set => created_at = value; }
    }
}