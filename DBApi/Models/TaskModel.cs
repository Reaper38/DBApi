using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBApi.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public CatalogModel Catalog { get; set; }
        public ApplicationUser User { get; set; }
    }
}