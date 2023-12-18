using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireBaseExp2
{
    public class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("dates")]
        public Date[] Dates { get; set; }
        public Item(string name, int price, Date date1, Date date2)
        {
            this.Name = name;
            this.Price = price;
            this.Dates = new Date[2];
            this.Dates[0] = date1;
            this.Dates[1] = date2;

        }
        public override string ToString()
        {
            return "name: " + this.Name;
        }
    }
}