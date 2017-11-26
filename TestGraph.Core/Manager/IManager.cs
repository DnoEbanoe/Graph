namespace TestGraph.Core.Manager
{
    public interface IManager<T>
    {
        T GetItemnByName(string name);
        void AddItem(string name, T item);
        void RemoveItem(string name);
    }
}
