using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : Controller
    {
        private readonly IListRepo _IListRepo;
        private readonly IListItemRepo _ListItemRepo;

        public ListController(IListRepo ListRepo, IListItemRepo ListItemRepo)
        {
            _IListRepo = ListRepo;
            _ListItemRepo = ListItemRepo;
        }


        [HttpGet("GetList")]
        public ActionResult<IEnumerable<Lists>> GetList()
        {
            var lists = _IListRepo.GetLists();
            return lists;
        }

        [HttpPost("ADDList")]
        public String AddList(String name)
        {
            try
            {
                _IListRepo.AddList(name);
                return " Added list successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPut("UpdateList")]
        public String UpdateList(String newName, int id)
        {
            try
            {
                _IListRepo.UpdateList(newName, id);
                return " Updated list successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete("DeleteList")]
        public String DeleteList(int id)
        {
            try
            {
                _IListRepo.DeleteList(id);
                return "List Deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet("GetListItems")]
        public ActionResult<IEnumerable<ListItems>> GetListItems(int listid)
        {
            var listitems = _ListItemRepo.GetListsItem(listid);
            return listitems;
        }
        [HttpPost("AddListItems")]
        public String AddListItems(String name, int ListId)
        {
            try
            {
                _ListItemRepo.AddListItem(name, ListId);
                return " Added list item successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPut("UpdateListItems")]
        public String UpdateListItems(String newName, int itemid, int listId)
        {
            try
            {
                _ListItemRepo.UpdateListItem(newName, itemid, listId);
                return " Updated list item successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpDelete("DeleteListItems")]
        public String DeleteListItems(int itemid, int listId)
        {
            try
            {
                _ListItemRepo.DeleteListItem(itemid, listId);
                return " List item deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

