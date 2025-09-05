using DataAccessLayer.Interfaces.Repositories;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IBaseRepository
    {
        public Guid Add<T>(T TObject) where T : class
        {
            throw new NotImplementedException();
        }

        public int Count<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Guid Delete<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(Guid id) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetPaginated<T>(int pageNumber, int pageSize) where T : class
        {
            throw new NotImplementedException();
        }

        public Guid Update<T>(T TObject) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
