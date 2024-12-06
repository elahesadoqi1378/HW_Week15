using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Week15.Entities;

namespace HW_Week15.DAL.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);
            

            builder.HasOne(t => t.SourceCard)
                .WithMany(c => c.SourceTransactions)
                .HasForeignKey(t => t.SourceCardNumber)
                .HasPrincipalKey(c => c.CardNumber) 
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.DestinationCard)
               .WithMany(c => c.DestinationTransactions)
               .HasForeignKey(t => t.DestinationCardNumber)
              .HasPrincipalKey(c => c.CardNumber) 
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
