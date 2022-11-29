using System;
using Microsoft.AspNetCore.Mvc;
using AspNetWebApiWithMongoDbAtlas.Models;
using AspNetWebApiWithMongoDbAtlas.Services;

namespace AspNetWebApiWithMongoDbAtlas.Controllers;

[Controller]
[Route("api/[controller]")]
public class PlaylistController : Controller
{
    private readonly MongoDbService _mongoDbService;

    public PlaylistController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Playlist))]
    [ProducesResponseType(StatusCodes.Status404NotFound)] //* se explanation below in developer notes
    public async Task<List<Playlist>> Get() {
        return await _mongoDbService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Playlist playlist) {
        await _mongoDbService.CreateAsync(playlist);
        return CreatedAtAction(nameof(Get), new {id = playlist.Id}, playlist); //returns Created (201)
    }

    [HttpPut("{id}")] 
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId) {
        await _mongoDbService.AddToPlaylistAsync(id, movieId);
        return NoContent(); //status 204 No Content, or Ok() status code 200;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete (string id) {
        await _mongoDbService.DeleteAsync(id);
        return NoContent(); 
    }


}

/* Developer Notes
    - https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-7.0#synchronous-action
    - Status 204 No Content indicates that a request has succeeded, but that the client doesn't need to navigate away from its current page. - MZDN
*/
