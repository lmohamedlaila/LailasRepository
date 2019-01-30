

using System.Linq;

namespace DataAccess.Repositories
{
    public interface IMatchRepository :IRepository
    {
        IQueryable<Match> GetAll();
    }
}
