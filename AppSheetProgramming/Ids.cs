using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace AppSheetProgramming
{
    // Contract class for serialization of response from list api
    [DataContract]
    class Ids
    {
        [DataMember(Name = "result")]
        public int[] result { get; set; }

        [DataMember(Name = "token")]
        public string token { get; set; }
    }
}
