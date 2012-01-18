BridgeStack
===========


This is a [StackExchange][2] API v2.0 consumer library written under `C#`. It is heavily documented and designed to make it as easy as humanly possible to interact with the API.


Example Usage
-------------


To get the name of each silver badge you've been awarded on [Stack Overflow][3]:

```c#
var client = new StackClientFactory().Create(_appKey, _token);
client.Default.Site = NetworkSiteEnum.StackOverflow;
var parameters = new BadgesOnUserQuery
{
    Sort = QuerySortEnum.BadgeRank,
    Min = BadgeRankEnum.Silver,
    Max = BadgeRankEnum.Silver
};
var badges = client.GetMyBadges(parameters);

foreach (var badge in badges)
{
    Console.WriteLine(badge.Name);
}
```
	
Line by Line Explanation:
-------------------------

```c#
var client = new StackClientFactory().Create(_appKey, _token);
```
A `StackClient` instance is created, passing in your application's key and the user's access token.

```c#
    client.Default.Site = NetworkSiteEnum.StackOverflow;
```
A default is set so that all requests made through this client which require a target site use [Stack Overflow][4]

```c#
var parameters = new BadgesOnUserQuery
{
	Sort = QuerySortEnum.BadgeRank,
	Min = BadgeRankEnum.Silver,
	Max = BadgeRankEnum.Silver
};
```
A query parameter object is created, using the `Rank` sort on badges, and setting the range to only `Silver` badges.

```c#
var badges = client.GetMyBadges(parameters);
```
The API is accessed, and the user badges are received from [StackExchange][5].

```c#
foreach (var badge in badges)
{
	Console.WriteLine(badge.Name);
}
```
The badges are then iterated, and their names are output to the console. Note that `badges`, while an `IEnumerable<T>`, contains valuable data other than the actual list items, like paging info, the actual response, exceptions that might have been thrown (and be the reason the enumeration is empty), etc.


About
-----


I created this library as a way to give back to the [StackOverflow][3] community, which has helped me out and taught me on countless ocassions.  
At all times I attempted to mantain the same philosophy in writting this library. I documented every method, reused as much code as possibly, mirrored the API as heavily as possible, and generally designed it with wrapping away complexity in mind.

BridgeStack is licensed under GNU/GPL.

  [2]: http://stackexchange.com
  [3]: http://stackoverflow.com
  [4]: http://stackoverflow.com
  [5]: http://stackexchange.com