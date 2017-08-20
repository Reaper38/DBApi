using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBApi.Models
{
    public class Catalogs
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Users
    {
        public string Name { get; set; }
        public string Login { get; set; }
    }

    public class Tasks
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Users Creator { get; set; }
        public Catalogs Catalog { get; set; }
    }
}