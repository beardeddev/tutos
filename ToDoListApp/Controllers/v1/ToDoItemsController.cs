using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Models;
using ToDoListApp.Repositories;

namespace TodoListApp.Controllers.v1
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ToDoItemsController : ApiControllerBase<ToDoItem, int>
    {
        public ToDoItemsController(IToDoItemRepository repository)
            : base(repository)
        {

        }
    }
}