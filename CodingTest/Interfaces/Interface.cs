using CodingTest.DataModel;

namespace CodingTest.Interfaces
{
    public interface IRepo<T>
    {
        T? GetEntity(int id);
        IEnumerable<T> GetAll();
    }
}
