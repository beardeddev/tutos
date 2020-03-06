using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Models;
using ToDoListApp.Repositories;

namespace TodoListApp.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ToDoListsController : ApiControllerBase<ToDoList, int>
    {
        public ToDoListsController(IToDoListRepository repository)
            : base(repository)
        {
            
        }
    }
}