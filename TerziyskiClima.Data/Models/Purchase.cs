using System;
using System.Collections.Generic;
using System.Text;

namespace TerziyskiClima.Data.Models
{
    public class Purchase
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

        public Purchase(int userId, int productId, DateTime date)
        {
            UserId = userId;
            ProductId = productId;
            Date = date;
        }
    }
}
