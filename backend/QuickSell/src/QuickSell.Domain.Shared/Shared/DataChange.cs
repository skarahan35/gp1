using Newtonsoft.Json;
using System.Collections.Generic;

namespace QuickSell.Shared
{
     public class DataChange
     {
          [JsonProperty("key")]
          public object Key { get; set; }
          [JsonProperty("type")]
          public string Type { get; set; }//INSERT,UPDATE,DELETE
          [JsonProperty("data")]
          public object Data { get; set; }

     }
}