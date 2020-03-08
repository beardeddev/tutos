using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class ToDoItem : IEntity<int>
    {
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDoList ToDoList { get; set; }
    }
}