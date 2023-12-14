using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MaterialManagementSystem.Models
{
    public class DbEntity:DbContext
    {
        public DbEntity() : base("DbEntity")
        {

        }
        public DbSet<Indent> Indents { get; set; }
    }
}