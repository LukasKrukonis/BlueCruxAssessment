namespace test.Models
{
    public interface IListRepo
    {
        List<Lists> GetLists();
        void AddList(String name);
        void UpdateList(String name, int id);
        void DeleteList(int id);

    }
}
