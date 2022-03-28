using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Services
{
    public class Cart
    {
        public List<CartItem> Items{ get; set; }

        public Cart (List<CartItem> items)
        {
            Items = items;
        }

        public Cart () : this(new List<CartItem>()) {}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}