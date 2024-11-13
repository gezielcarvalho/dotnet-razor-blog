﻿using dotnet_razor_blog.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dotnet_razor_blog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
