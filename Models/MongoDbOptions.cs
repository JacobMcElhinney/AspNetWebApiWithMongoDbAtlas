namespace AspNetWebApiWithMongoDbAtlas.Models;

/// <summary>
/// A representation of the configuration section in appsettings. 
/// the custom Options class is used to read related configuration values in appsettings.json. 
/// (Or the environment specified in ../Properties/launchSettings.json). 
/// Each class member property has a binding to a configuration value with a corresponding name. 
/// Options Class: implementation of Options Pattern in .NET (Microsoft.Extensions.Options.IOptions).
/// </summary>
public class MongoDbOptions
{
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
    public string? CollectionName { get; set; }
}