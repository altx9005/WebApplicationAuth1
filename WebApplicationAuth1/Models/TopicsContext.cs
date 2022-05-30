using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplicationAuth1.Models
{
    public class TopicsDBContext : DbContext
    {
        public TopicsDBContext()
        { }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }

    }

}