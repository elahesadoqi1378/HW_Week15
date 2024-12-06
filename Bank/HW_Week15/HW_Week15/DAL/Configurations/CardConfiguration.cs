using HW_Week15.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.DAL.Configurations 
{
    public class CardConfiguration :IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);
            
            
            
               

            builder.HasData(new List<Card>()
            {
                new Card() {Id=1,CardNumber="6219861917648627",HolderName="Elahe",Password="1234",Balance=1000,UserId=1},
                new Card() {Id=2,CardNumber="6274121181669466",HolderName="Amir",Password="1234",Balance = 2000,UserId=2},
                new Card() {Id=3,CardNumber="6104337864729130",HolderName="Leila",Password="1234",Balance = 3000,UserId=3},
                new Card() {Id=4,CardNumber="6037701523192418",HolderName="Sara",Password="1234",Balance = 6000,UserId=4},
                new Card() {Id=5,CardNumber="6037701923372541",HolderName="Miko",Password="1234",Balance = 5000,UserId=5}


            });
        }
    }
}
