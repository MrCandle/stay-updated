# stay-updated rc1

## Arch
This project was created using MVC5 and EF6.

## Use cases

1. User should be able to subscribe to a news feed.
2. User should be able to view items in a news feed.
3. User should be able to search for news feed items.
4. User should be able to see a listing of all news items from all
feeds.
5. Add any features / functionality that you would want in a feed
reader.


## Approach taken

My first approach was to create a Service that would be subscribed to RSS Feeds from several news pages, but that required the creation of a Windows Service in order to leave it running on the background.

Due to time constraints, I had to use a third party library called [NewsAPI.org](https://newsapi.org/) which is free for development as long as you gave some credit to them (I did).

As I found this API which helped me a lot, I wondered how could I improve the app and give the user a better experience,
so I created the UserSettings model and service.

The UserSettings are the one used to query the NewsAPI, filtering by the user location and language. This settings are also capable of handling pagination as an upcoming feature.

The sources are also being load from NewsAPI.org, and you can check up to 20 sources which will be applied (and stored) to query the newsAPI.

## Current design errors / bugs

There's a menu that says "Sources", that one is not working.
apikey, used by newsapi, is not stored in the web.config and it should.


## How to run

Download, open the solution with VS 2015/2017 and press F5.

