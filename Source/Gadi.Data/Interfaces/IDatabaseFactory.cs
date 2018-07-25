namespace Gadi.Data.Interfaces
{
    public interface IDatabaseFactory<T>
    {
        T CreateContext();
    }
}
