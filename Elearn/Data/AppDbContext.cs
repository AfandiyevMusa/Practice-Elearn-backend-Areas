using System;
using Elearn.Models;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Data
{
	public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<Choose> Chooses { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<NewsAuthor> NewsAuthors { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsImages> newsImages { get; set; }
    }
}

