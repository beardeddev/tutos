using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class ToDoList : IEntity<int>
    {
        public int Id { get; set; }

        [Required, MaxLength(256)]
        public string Title { get; set; }

        [Required]
        public List<ToDoItem> Items { get; set; }
    }
}