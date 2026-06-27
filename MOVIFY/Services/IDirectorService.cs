using MOVIFY.Model;
using System.Collections.Generic;

namespace MOVIFY.Services
{
    public interface IDirectorService
    {
        IEnumerable<Director> GetAllDirectors();
        void AddDirector(Director director);
        Director GetDirectorById(int id);
        void UpdateDirector(Director director);
        void DeleteDirector(int id);
    }
}