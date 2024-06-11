# ChatGptColorApi
An api that takes a list of colors and fixes typos/converts to readable names. For example, if we list "Red, Green, Blue". It will change "Scarlet" to "Red".

Uses VS 2017. Doesn't require NuGet packages to hit Chat Gpt!

How to Run:
This is an api, run the debugger or host the api.
Then hit this endpoint:
yoursite.com/api/ColorInterpreter?colors=red,bure,read

Expected Response:
Red, Blue, Red


To modify expected responses, modify the method "GetPossibleColorNames" in the Services/ColorInterpreterService.cs.

Have fun!
