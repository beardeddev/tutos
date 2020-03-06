using ToDoListApp.Models;
using ToDoListApp.Repositories;

namespace ToDoListApp.Repositories
{
    public class ToDoListRepository : Repository<ToDoList, int>, IToDoListRepository
    {
        public ToDoListRepository(ToDoDbContext context)
            : base(context)
        {
            
        }
    }
}