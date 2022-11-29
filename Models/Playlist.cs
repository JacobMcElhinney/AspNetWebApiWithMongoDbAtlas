using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace AspNetWebApiWithMongoDbAtlas.Models {

    // [BsonIgnoreExtraElements]
    public class Playlist {

        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)] //converts it to MongoDB compatible type and name: _id 
        public string? Id { get; set; } //?: can be null at runtime. If so MongoDb will generate an _id for us (since we identified it as the _id using attributes).

        //Null-forgiving operator: expression will evaluate to the result of the underlying expression at runtime.
        [BsonElement("username")]
        [JsonPropertyName("username")]
        public string Username { get; set; } = null!; //Will not be null at runtime.

        [BsonElement("items")] // If our model property name is different from the bson field name in mongo db, we can bind to the correct name using the BsonElement attribute
        [JsonPropertyName("items")] // custom  name of serialised json property
        public List<string>? MovieIds { get; set; }
    }
}

// Developer Note !(Null-forgiving) operator: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving
// By using the null-forgiving operator, you inform the compiler that passing null is expected and shouldn't be warned about.
/*
/// Notice that the models use data attributes for the Id property and camelCase naming convention (just like c# variables) in order to map to the corresponding document in MongoDb.
    /// To avoind compiler warnings in cases when we know the value will not be null at runtime, We declare properties as nullable using the "?" postfix and use the null-forgiving operator (null!) for values that will be provided at runtime.
*/