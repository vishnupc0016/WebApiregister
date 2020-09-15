using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiregister.Model;

namespace WebApiregister.Models
{
    public class registerContextClass:DbContext
    {
        public registerContextClass(DbContextOptions<registerContextClass> options) : base(options)
        { }
        public DbSet<registration> uregister { get; set; }

    }
}
