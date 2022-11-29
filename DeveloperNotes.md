---
title: Example Title
description: example description
slug: example-title
---



---
title: Developer Notes
description: Brief notes on the development process and the steps involved in completing the tutorial.
tutorial: [Create a RESTful API with .NET Core and MongoDB](https://www.mongodb.com/developer/languages/csharp/create-restful-api-dotnet-core-mongodb/), [video](https://www.youtube.com/watch?v=jJK9alBkzU0&list=PLQBK8mAp3rE9IZilL8sZqylWEs4GNWgH-&index=16)
---

# Exercise 2 - Developer Notes

## Project Setup

```pwsh
# Generate Web API Boilerplate from template
dotnet new webapi

# Generate gitignore file
dotnet new gitignore

# Install MongoDB drivers
dotnet add package MongoDB.Driver
```

### Application Folder Structure
Example from Express.js 
```csharp
.
├── bin
├── Controllers // PlaylistController.cs
├── Models // Playlist.cs
├── bin
├── Properties
├── Services // MongoDbService.cs
├── .gitignore
├── appsettings.Development.json
├── appsettings.json
├── AspNetWebApiWithMongoDbAtlas.csproj
├── DevelopersNotes.md // Additional notes for when you follow the tutorial
├── Program.cs
└── README.md
```

## On Tutorial completion

Use both the [written](https://www.mongodb.com/developer/languages/csharp/create-restful-api-dotnet-core-mongodb/) and the [video](https://www.youtube.com/watch?v=jJK9alBkzU0&list=PLQBK8mAp3rE9IZilL8sZqylWEs4GNWgH-&index=16) tutorial to complete the exercise. 

Once you are done, Try it out using the swagger UI at: `http://localhost:<Port>/swagger`
you can find port in the terminal output once you run the application using `dotnet run`:  
```pwsh
PS /Users/jacobmcelhinney/Desktop/Lektion 2/AspNetWebApiWithMongoDbAtlas> dotnet run
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5090
```

Don't mind any redirection warnings for now... 

Use a real movie ObjectId (**MongoDB Atlas** > **Database** > **`<MyCluster>`** > **Browse Collections** > **movies**) as the element supplied to the items Arrays *OR* try posting *fake data*

*POST example*
```json
{
    "username": "jacob",
    "items": [
        "8234857832745"
    ]
}
```
