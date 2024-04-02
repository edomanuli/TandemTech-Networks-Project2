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
            builder.HasData(
                    new User
                    {
                        Id = new Guid("06917677-cdd6-4523-91b8-88d6d0a912d2"),
                        FirstName = "Carson",
                        LastName = "Alexander",
                        Email = "calexander@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = new Guid("798acf1b-7339-44bd-8367-7132a978d7b1"),
                        FirstName = "Meredith",
                        LastName = "Alonso",
                        Email = "malonso@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = new Guid("2a36409f-6732-459b-b7d1-a561c521a3cb"),
                        FirstName = "Arturo",
                        LastName = "Anand",
                        Email = "aanand@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = new Guid("7d84360e-4967-4c7b-8e4c-0f085de7ca4d"),
                        FirstName = "Gytis",
                        LastName = "Barzdukas",
                        Email = "gbarzdukas@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = new Guid("7a1be69a-38ac-4cde-a105-615de38c2d12"),
                        FirstName = "Yan",
                        LastName = "Li",
                        Email = "yli@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = new Guid("5e9c10d4-3b0a-4ccb-8a77-fb2d7e702c6b"),
                        FirstName = "Peggy",
                        LastName = "Justice",
                        Email = "pjustice@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = new Guid("53cea385-aa61-4e81-ba7a-38d7ed60ce4f"),
                        FirstName = "Laura",
                        LastName = "Norman",
                        Email = "lnorman@contosouniversity.edu",
                    },
                    new User
                    {
                        Id = new Guid("554039c7-cba1-4404-9fbe-21918a9190f7"),
                        FirstName = "Nino",
                        LastName = "Olivetto",
                        Email = "nolivetto@contosouniversity.edu",
                    }
             );
        }
    }
}
