AppSheetProgramming
===================

Service endpoint:

1. list : http://natesabino.com/api/list (takes token as optional parameter to get next set of ids)

2. detail: http://natesabino.com/api/detail/:id (:id is the id of user fetched from list endpoint above) 

Six classes:

1. Service: A utility class to make http request to an endpoint using makeRequest() function. Endpoint uri is passed to the function as parameter.

2. UserIds: Class to make request to list endpoint and get response as de-serialized object Ids (defined below).

3. UserDetail: Class to make request to detail endpoint and get response as de-serialized object Detail (defined below).

4. Ids: Contract class used by JSON serializer to de-serialize response from list endpoint. (check UserIds above)

5. Detail: Contract class used by JSON serializer to de-serialize response from detail endpoint. (check UserDetail above)

6. FiveYoungestUsers: Main class to get list of five youngest users with valid telephone numbers. The list is sorted by name alphabetically.

Approach to get five youngest users with valid phone numbers:

Make request to list endpoint and get the ids. For each id, make a request to detail endpoint and populate a list of final response only if phone number is valid. When the size of final response list reaches 5, for new responses from detail endpoint replace the list item with max age with the item in response if age is smaller than max age in the list. After all the responses from details API is processed, the list will contain youngest users with valid phone number. Order this list by the name of the user and return as output.
