using System;
using System.Collections.Generic;
using System.Text;

namespace TerziyskiClima.Services.Interfaces
{
    public interface IPurchaseService
    {
        public void PurchaseFromCart(int userId, string cartString);
    }
}
