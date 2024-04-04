using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configure relationships
            builder.HasMany(u => u.UserPlans)
                .WithOne(up => up.User)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Seed data
            builder.HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Carson",
                        LastName = "Alexander",
                        Email = "calexander@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Meredith",
                        LastName = "Alonso",
                        Email = "malonso@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Arturo",
                        LastName = "Anand",
                        Email = "aanand@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = 4,
                        FirstName = "Gytis",
                        LastName = "Barzdukas",
                        Email = "gbarzdukas@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = 5,
                        FirstName = "Yan",
                        LastName = "Li",
                        Email = "yli@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = 6,
                        FirstName = "Bob",
                        LastName = "Justice",
                        Email = "pjustice@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = 7,
                        FirstName = "Laura",
                        LastName = "Norman",
                        Email = "lnorman@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = 8,
                        FirstName = "Nino",
                        LastName = "Olivetto",
                        Email = "nolivetto@contosouniversity.edu",
                    }
             );
        }
    }
}
