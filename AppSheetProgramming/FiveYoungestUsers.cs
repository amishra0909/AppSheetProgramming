using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSheetProgramming
{
    class FiveYoungestUsers
    {
        private const int NUMBER_OF_USERS = 5; 
        private UserIds userIds = new UserIds();
        private UserDetail userDetail = new UserDetail();

        // public member function which gets five youngest users with valid telephone number.
        public Detail[] getUserDetails()
        {
            // To get list of five youngest users, the idea is to create a list of five detail api responses
            // and replace the current max age element with the new response only if age in new response is
            // smaller than list element with max age. Thus, all responses from apis need not be stored in memory.

            List<Detail> details = new List<Detail>();         
            Ids ids = userIds.getIds();
            updateUserDetailsFromCurrentIds(ids.result, details);
            while (!String.IsNullOrEmpty(ids.token))
            {
                ids = userIds.getIds(ids.token);
                updateUserDetailsFromCurrentIds(ids.result, details);
            }

            // sort by name and return array of names
            return details.OrderBy(item => item.name).ToArray();
        }

        private void updateUserDetailsFromCurrentIds(int[] ids, List<Detail> details)
        {
            foreach (int id in ids)
            {
                Detail response = userDetail.getDetailForUserId(id);

                // response is null for users with invalid phone numbers
                if (response == null)
                {
                    continue;
                }

                if (details.Count < NUMBER_OF_USERS)
                {
                    details.Add(response);
                }
                else
                {
                    int maxAgeInList = details.Max(obj => obj.age);
                    if (maxAgeInList > response.age)
                    {
                        Detail maxAgeElement = details.Where(obj => obj.age == maxAgeInList).First();
                        details.Remove(maxAgeElement);
                        details.Add(response);
                    }
                }
            }
        }

        // main function to show results on console.
        static void Main(string[] args)
        {
            FiveYoungestUsers fiveYoungestUsers = new FiveYoungestUsers();

            // get names of five youngest users with valid telephone numbers sorted by name.
            Detail[] details = fiveYoungestUsers.getUserDetails();

            // print resutls to console.
            Console.WriteLine("5 youngest users with valid telephone numbers sorted by name :\n");
            foreach (Detail detail in details)
            {
                Console.Write(detail.name);
                Console.Write(" : { id:" + detail.id);
                Console.Write(", age:" + detail.age);
                Console.WriteLine(", number:" + detail.number + " }");
            }

            // press any key to exit
            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
