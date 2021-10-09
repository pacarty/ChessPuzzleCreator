using Puzzle.Models;

namespace Puzzle.Services
{
    public interface IUserService
    {
        void RegisterUser(string username, string password);
    }
}