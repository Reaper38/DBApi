using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBApi.Models
{
    public class CatalogModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}