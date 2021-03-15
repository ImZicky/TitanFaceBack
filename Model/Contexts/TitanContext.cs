using Microsoft.EntityFrameworkCore;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Contexts
{
    public class TitanContext: DbContext
    {
        public TitanContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OriginalTitan> OriginalTitans { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
