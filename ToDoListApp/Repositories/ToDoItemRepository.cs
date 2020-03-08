using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public class ToDoItemRepository : Repository<ToDoItem, int>, IToDoItemRepository
    {
        public ToDoItemRepository(ToDoDbContext context)
            : base(context)
        {

        }
    }
}