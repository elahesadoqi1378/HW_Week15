using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public float Balance { get; set; }
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }
        public int FailedLoginAttempts { get; set; } = 0;

        #region NavigationProperties
        public List<Transaction> SourceTransactions { get; set; }
        public List<Transaction> DestinationTransactions { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        #endregion
    }

}
