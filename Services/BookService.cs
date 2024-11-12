using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbApi.Models;

namespace MongoDbApi.Services;

public class BookService
{
    private readonly IMongoCollection<Book> _books;

    public BookService(IOptions<MongoDbSettings> mongoDbSettings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _books = database.GetCollection<Book>("Books");
    }

    public async Task<List<Book>> GetAsync() =>
        await _books.Find(_ => true).ToListAsync();

    public async Task<Book> GetAsync(string id) =>
        await _books.Find(book => book.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Book book) =>
        await _books.InsertOneAsync(book);

    public async Task UpdateAsync(string id, Book book) =>
        await _books.ReplaceOneAsync(book => book.Id == id, book);

    public async Task DeleteAsync(string id) =>
        await _books.DeleteOneAsync(book => book.Id == id);
}
