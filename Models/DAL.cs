using System.Data.SqlClient;

namespace test.Models
{
    public class DAL : IListRepo , IListItemRepo
    {
        public IConfiguration Config { get; }
        public static List<Lists> lists = new List<Lists>();
        public static List<ListItems> listsitems = new List<ListItems>();
        
        public DAL(IConfiguration configuration)
        {
            Config = configuration;
        }

        public  List<Lists> GetLists()
        {

            using (SqlConnection con = new SqlConnection(Config.GetConnectionString("ListContext")))
            {
                lists.Clear();
                string query = "SELECT * From Lists";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lists.Add(new Lists
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = Convert.ToString(reader["name"]),
                            });
                        }
                    }
                    con.Close();

                }
                return lists;
            }
        }

        public void AddList(String name)
        {
         
            using (SqlConnection con = new SqlConnection(Config.GetConnectionString("ListContext")))
            {
                string query = "Insert INTO Lists (Name) VALUES (@name)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateList(String newName, int id)
        {
            using (SqlConnection con = new SqlConnection(Config.GetConnectionString("ListContext")))
            {
                string query = "Update Lists Set Name = @name Where Id = @id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteList(int id)
        {
            using (SqlConnection con = new SqlConnection(Config.GetConnectionString("ListContext")))
            {
                string query = "DELETE FROM Lists Where Id = @id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }


        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



       public List<ListItems> GetListsItem(int id)
        {
            using (SqlConnection con = new SqlConnection(Config.GetConnectionString("ListContext")))
            {
                listsitems.Clear();
                string query = "SELECT * From ListItems Where Id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listsitems.Add(new ListItems
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                itemId = Convert.ToInt32(reader["itemId"]),
                                Name = Convert.ToString(reader["name"]),
                            });
                        }
                    }
                    con.Close();

                }
                return listsitems;
            }
        }
       public void AddListItem(String name, int ListId)
        {

            using (SqlConnection con = new SqlConnection(Config.GetConnectionString("ListContext")))
            {
                string query = "Insert INTO ListItems (Id , Name) VALUES (@ListId,@name)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@ListId", ListId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateListItem(String newName, int id, int ListId)
        {
            using (SqlConnection con = new SqlConnection(Config.GetConnectionString("ListContext")))
            {
                string query = "Update ListItems Set Name = @name Where Id = @listid AND itemId = id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@listid", ListId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteListItem(int id, int ListId)
        {
            using (SqlConnection con = new SqlConnection(Config.GetConnectionString("ListContext")))
            {
                string query = "Delete From ListItems Where Id = @listid AND itemId = @id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@listid", ListId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }




    }
}
