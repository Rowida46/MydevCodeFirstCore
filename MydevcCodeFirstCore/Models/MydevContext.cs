using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MydevcCodeFirstCore.Models
{
    public class MydevContext : DbContext
    {
        public MydevContext(DbContextOptions nameorstringconnection) : base(nameorstringconnection){ }

        public DbSet<Articles> articles { get; set; }
        public DbSet<LogIn> logins { get; set; }
    }
}
