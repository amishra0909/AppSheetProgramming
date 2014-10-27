using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace AppSheetProgramming
{
    // Contract class for serialization of response from detail api
    [DataContract]
    class Detail
    {
        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "number")]
        public string number { get; set; }
        
        [DataMember(Name = "age")]
        public int age { get; set; }
    }
}
