namespace Domain
{
    public interface IManager<T>

    {
    public void Add();
    public T Get();
    public void Delete();
    }
}