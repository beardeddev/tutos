using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Models;
using ToDoListApp.Repositories;

namespace TodoListApp.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ToDoListController : ApiControllerBase<ToDoList, int>
    {
        public ToDoListController(IToDoListRepository repository)
            : base(repository)
        {
            
        }
    }
}