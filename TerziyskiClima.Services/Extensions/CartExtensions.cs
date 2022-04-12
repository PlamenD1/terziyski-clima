using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerziyskiClima.Services.Extensions
{
    public static class CartExtensions
    {
        public static Cart ToCart(this string str)
        {

            return JsonConvert.DeserializeObject<Cart>(str);
        }
    }
}