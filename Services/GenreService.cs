using BookStore.Data;
using BookStore.Models;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;


namespace BookStore.Services
{
    public class GenreService
    {
        public readonly BookstoreContext _context;

        public GenreService(BookstoreContext context)
        { _context = context; }

        public List<Genre> FindAll()
        {
            return _context.Genres.ToList();
        }

        // GET: Genres
        public async Task<List<Genre>> FindAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        // POST: Genres/Create
        public async Task InsertAsync(Genre genre)
        {
            _context.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<Genre> FindByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }
    }
}