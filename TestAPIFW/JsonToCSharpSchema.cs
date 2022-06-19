using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestAPIFW
{
    public class JsonToCSharpSchema
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        [DataContract]
        public class BasicUserDetails
        {
            [DataMember]
            public int userId { get; set; }
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string body { get; set; }
        }
    }
}
