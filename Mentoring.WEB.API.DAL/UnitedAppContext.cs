using Mentoring.WEB.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.WEB.API.DAL
{
    public class UnitedAppContext : DbContext
    {
        public UnitedAppContext(DbContextOptions<UnitedAppContext> options) : base(options)
        {}

        public DbSet<University> Universities { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
    }
}
