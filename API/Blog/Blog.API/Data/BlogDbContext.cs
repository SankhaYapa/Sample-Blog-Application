﻿using Blog.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }
        //DbSet
        public DbSet<Post> Posts { get; set; }
    }
}
