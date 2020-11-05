using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDMSWeb.Models
{
    /* DTO for List table */
    public class List
    {
        /* List properties */
        private int animeId;
        private int accountId;
        private string status;
        private int progress;
        
        /* Constructors */
        public List()
        {
        }

        public List(int animeId, int accountId, string status, int progress)
        {
            this.animeId = animeId;
            this.accountId = accountId;
            this.status = status;
            this.progress = progress;
        }

        /* Getters and Setters */
        public int AnimeId { get => animeId; set => animeId = value; }
        public int AccountId { get => accountId; set => accountId = value; }
        public string Status { get => status; set => status = value; }
        public int Progress { get => progress; set => progress = value; }
    }
}