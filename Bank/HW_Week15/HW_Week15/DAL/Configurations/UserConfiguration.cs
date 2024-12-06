using HW_Week15.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            

            builder.HasMany(u => u.Cards)
                .WithOne(c => c.User)
                .HasForeignKey(c=>c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<User>()
        {
            new User() { Id = 1, UserName = "Elahe", Email = "elahe@gmail.com" },
            new User() { Id = 2, UserName = "Amir", Email = "amir@gmail.com" },
            new User() { Id = 3, UserName = "Leila", Email = "leila@gmail.com" },
            new User() { Id = 4, UserName = "Sara", Email = "sara@gmail.com" },
            new User() { Id = 5, UserName = "Miko", Email = "miko@gmail.com" }
        });

        }
    }
}
