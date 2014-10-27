using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;

namespace AppSheetProgramming
{
    class Service
    {
        // Method to make http request to uri and return serialized parseType response.
        public object makeRequest(string uri, Type parseType)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                            "Server Error (HTTP {0} : {1}.",
                            response.StatusCode,
                            response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(parseType);
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    return objResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e.Message);
                throw e;
            }
        }
    }
}
