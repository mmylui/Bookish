namespace Bookish;
using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

public interface IAuthorRepo
{
    List<AuthorModel> GetAuthors();
    AuthorModel GetAuthorById(int id);
    List<AuthorModel> SearchAuthors(string query);
}
public class AuthorRepo : IAuthorRepo
{
    private readonly BookishDbContext _context;

    public AuthorRepo(BookishDbContext context)
    {
        _context = context;
    }

    public List<AuthorModel> GetAuthors()
    {
        return _context.Authors
            .Include(b => b.Books)
            .Include(b => b.Copies)
            .ToList();
    }

    public AuthorModel GetAuthorById(int id)
    {
        return _context.Authors
            .Include(b => b.Books)
            .Include(b => b.Copies)
            .Where(b => b.Id == id)
            .Single();
    }

    public List<AuthorModel> SearchAuthors(string query)
    {
        return _context.Authors
            .Include(b => b.Books)
            .Include(b => b.Copies)
            .Where(b => b.Name == query)
            .ToList();
    }

}