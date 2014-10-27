using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AppSheetProgramming
{
    class UserDetail
    {
        Service service = new Service();

        // Get the details for a user with given id. Returns null, if the phone number is not valid.
        public Detail getDetailForUserId(int id)
        {
            string request = createRequest(id);
            Detail detail = service.makeRequest(request, typeof(Detail)) as Detail;
            if (isNumberValidInResponse(detail.number))
            {
                return detail;
            }
            return null;
        }

        // Helper function to make request for detail api.
        // An assumption is any id is valid, so it becomes the responsibility of caller to
        // call this function with ids returned by ListRequestHelper.
        private string createRequest(int id)
        {
            return "http://natesabino.com/api/detail/" + id;
        }

        //Helper function to check if phone number is valid
        private bool isNumberValidInResponse(string number)
        {
            // A naive way to check the validity of phone numbers. Remove all the non-digit
            // characters from number and check if the length is 10. Assumption here is all
            // number strings which contain set of 10 digits are valid phone numbers.
            Regex reDigits = new Regex(@"[^\d]");
            number = reDigits.Replace(number, "");
            return number.Length == 10;
        }
    }
}
