using eRandevuApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Data
{
    public class RandevuDbContext:IdentityDbContext<Kullanici>
    {
        public RandevuDbContext(DbContextOptions<RandevuDbContext> options)
            : base(options)
        {

        }

        //Poliklinik ve doktor arasındaki ilişki many to many olduğundan PoliklinikDoktor adında bir tablomuz daha olacak. Bunun konfigürasyonu ise fluent api kullanılarak aşağıdaki gibi yapılır.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PoliklinikDoktor>().HasKey(fo => new { fo.DoktorId , fo.PoliklinikId });
            modelBuilder.Entity<PoliklinikDoktor>().HasOne(m => m.Poliklinik).WithMany(fo => fo.PolikliniklerDoktorlar).HasForeignKey(m => m.PoliklinikId);
            modelBuilder.Entity<PoliklinikDoktor>().HasOne(m => m.doktor).WithMany(fo => fo.PolikliniklerDoktorlar).HasForeignKey(m => m.DoktorId);

            base.OnModelCreating(modelBuilder);
        }

        
        public DbSet<Poliklinik> poliklinikler { get; set; }
        public DbSet<doktor> Doktorlar { get; set; }
        public DbSet<Hastane> Hastaneler { get; set; }
        public DbSet<Bashekim> Bashekimler { get; set; }    
        public DbSet<PoliklinikDoktor> PolikliniklerDoktorlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<RandevuPoliklinik> RandevuPoliklinikler { get; set; }

        //sepetler->sepettekileri tutuyor
        public DbSet<Sepet> Sepetler { get; set; }

    }
}
