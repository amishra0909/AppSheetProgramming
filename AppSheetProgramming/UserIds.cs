using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSheetProgramming
{
    class UserIds
    {
        Service service = new Service();

        // Get the List of user ids. Token is used to get next list of ids. 
        public Ids getIds(string token = null)
        {
            string request = createRequest(token);
            Ids ids = service.makeRequest(request, typeof(Ids)) as Ids;
            return ids;
        }

        // Static helper function to make request for list api.
        private string createRequest(string token)
        {
            string urlRequest = "http://natesabino.com/api/list/";
            if (!String.IsNullOrEmpty(token))
            {
                urlRequest = urlRequest + "?token=" + token;
            }
            return urlRequest;
        }
    }
}
