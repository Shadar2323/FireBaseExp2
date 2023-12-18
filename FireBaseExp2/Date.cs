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
    public class Date
    {
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("month")]
        public int Month { get; set; }
        [JsonProperty("day")]
        public int Day { get; set; }

        public override string ToString()
        {
            return "Year: " + this.Year + " Month: " + this.Month + " Day: " + this.Day;
        }
    }
}