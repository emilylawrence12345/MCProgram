using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace HeathCareMemberCoreProj
{
    public class DataBaseSettings
    {
        [JsonProperty]
        public static bool LogInfoFlag { get; set; }
        [JsonProperty]
        public static bool LogTraceFlag { get; set; }
        [JsonProperty]
        public static bool LogDebugFlag { get; set; }
        [JsonProperty]
        public static bool LogWarnFlag { get; set; }
    }
}
