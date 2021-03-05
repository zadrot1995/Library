using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Сategory> Categories { get; set; }
        public ApplicationContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
    }
}
