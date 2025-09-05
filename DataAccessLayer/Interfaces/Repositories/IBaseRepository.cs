namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        Guid Add<T>(T TObject) where T : class;  

        Guid Update<T>(T TObject) where T: class;

        T GetById<T>(Guid id) where T : class;

        int Count<T>() where T : class; 

        IEnumerable<T> GetPaginated<T>(int pageNumber, int pageSize) where T : class;

        Guid Delete<T>() where T : class;   
    }
}
