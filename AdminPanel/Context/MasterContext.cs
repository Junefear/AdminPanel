using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using AdminPanel.Models;

namespace AdminPanel.Models
{
    public class MasterContext : DbContext
    {
        public MasterContext() : base("MasterConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MasterContext, FepazoConfiguration>("MasterConnection"));
        }

        #region Tables

        public DbSet<News> News { get; set; }
        public DbSet<HotProduct_Group> Product_Gruop { get; set; }
        public DbSet<HotProduct> Product { get; set; }
        public DbSet<owl_ContactInformations> Contact { get; set; }
        public DbSet<owl_HomeSlider> HomeSlider { get; set; }
        public DbSet<owl_DynamicPage> DynamicPage { get; set; }
        public DbSet<owl_PhotoGallery> PhotoGallery { get; set; }
        public DbSet<owl_Account> Account { get; set; }



        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }

    internal sealed class FepazoConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<MasterContext>
    {
        public FepazoConfiguration()
        {
            AutomaticMigrationsEnabled = true; // Veritabanını buradaki modellere göre son haline güncelleme
            AutomaticMigrationDataLossAllowed = true; // Bu güncelleme işlemi yaparken olabilecek veri kaybına izin verme (true)
        }
    }

}