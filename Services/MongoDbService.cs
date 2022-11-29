using AspNetWebApiWithMongoDbAtlas.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace AspNetWebApiWithMongoDbAtlas.Services;


// TODO: Refactor entire service class, take the best from both approaches.
public class MongoDbService
{
    private readonly IMongoCollection<Playlist> _playlistCollection;

    public MongoDbService(IOptions<MongoDbOptions> mongoDbOptions)
    {
        MongoClient client = new MongoClient(mongoDbOptions.Value.ConnectionString);
        IMongoDatabase database = client.GetDatabase(mongoDbOptions.Value.DatabaseName);
        _playlistCollection = database.GetCollection<Playlist>(mongoDbOptions.Value.CollectionName);
    }

    public async Task<List<Playlist>> GetAsync()
    {
        // The Find operation will return all documents that exist in the collection.
        return await _playlistCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task CreateAsync(Playlist playlist)
    {
        await _playlistCollection.InsertOneAsync(playlist);
        return;
    }

    public async Task AddToPlaylistAsync(string id, string movieId)
    {
        // Set up a match filter to determine which document or documents should receive the update.
        FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);
        // defining update criteria only adding an item to the array if it doesn't already exist in the array.
        UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("items", movieId); //See note at bottom of file
        await _playlistCollection.UpdateOneAsync(filter, update);
        return;
    }
    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);
        // Delete single document based on filter criteria
        await _playlistCollection.DeleteOneAsync(filter);
        return;
    }
}

/* Developer Notes
Notice that when using Builders<Playlist>.Update.AddToSet<string>(field: "items", value: movieId); 
we are passing the field name defined by our attributes in our Playlist model. 
*/