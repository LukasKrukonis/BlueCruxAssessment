namespace test.Models
{
    public interface IListItemRepo
    {
        List<ListItems> GetListsItem(int id);
        void AddListItem(String name,int ListId);
        void UpdateListItem(String name, int id,int ListId);
        void DeleteListItem(int id, int ListId);
    }
}
