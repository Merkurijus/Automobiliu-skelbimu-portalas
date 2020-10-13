using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Automobiliu_skelbimu_portalas.Models;


namespace Automobiliu_skelbimu_portalas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Damage> Damages { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<GearBox> GearBoxes { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Marked> MarkedList { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Searches> SearchesList { get; set; }
        public DbSet<User> UsersList { get; set; }
        public DbSet<Viewed> ViewedList { get; set; }
        public DbSet<Automobiliu_skelbimu_portalas.Models.AdVM> AdVM { get; set; }
        public DbSet<Automobiliu_skelbimu_portalas.Models.ColorVM> ColorVM { get; set; }
        public DbSet<Automobiliu_skelbimu_portalas.Models.DamageVM> DamageVM { get; set; }
        public DbSet<Automobiliu_skelbimu_portalas.Models.FuelTypeVM> FuelTypeVM { get; set; }
        public DbSet<Automobiliu_skelbimu_portalas.Models.GearBoxVM> GearBoxVM { get; set; }
        public DbSet<Automobiliu_skelbimu_portalas.Models.ModelVM> ModelVM { get; set; }
       
       
    }
}
