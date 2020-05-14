﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lemontech.DataLayer.Entities
{
    public class IdentityDBContext : IdentityDbContext<IdentityUser>
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
