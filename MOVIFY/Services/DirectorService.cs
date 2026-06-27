using MOVIFY.Data.Data;
using MOVIFY.Model;
using System.Collections.Generic;
using System.Linq;

namespace MOVIFY.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly ApplicationDbContext _context;

        public DirectorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Director> GetAllDirectors()
        {
            return _context.Directors.ToList();
        }

        public void AddDirector(Director director)
        {
            _context.Directors.Add(director);
            _context.SaveChanges();
        }

        public Director GetDirectorById(int id)
        {
            return _context.Directors.Find(id);
        }

        public void UpdateDirector(Director director)
        {
            _context.Directors.Update(director);
            _context.SaveChanges();
        }

        public void DeleteDirector(int id)
        {
            var director = _context.Directors.Find(id);
            if (director != null)
            {
                _context.Directors.Remove(director);
                _context.SaveChanges();
            }
        }
    }
}