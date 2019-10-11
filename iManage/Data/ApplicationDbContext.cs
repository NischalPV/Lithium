using iManage.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iManage.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>().HasData(
                new Client() { Name="Nischal Varasada", Phone="+91 84699 40719", Occupation="Invert Triangle", CreatedDate= new DateTime(2019, 4, 19, 0, 19, 0, 0, DateTimeKind.Local).AddTicks(0) },
                new Client() { Name= "Rishi Varasada", Phone="+91 84699 40719", Occupation="Invert Triangle", CreatedDate= new DateTime(2019, 4, 19, 0, 19, 0, 0, DateTimeKind.Local).AddTicks(0) },
                new Client() { Name= "Payal Varasada", Phone="+91 84699 40719", Occupation="Invert Triangle", CreatedDate= new DateTime(2019, 4, 19, 0, 19, 0, 0, DateTimeKind.Local).AddTicks(0) }
                );
        }
    }


}
