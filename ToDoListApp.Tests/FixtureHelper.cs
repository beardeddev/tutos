using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApp.Models;

namespace ToDoListApp.Tests
{
    public static class FixtureHelper
    {
        public static void LoadFixtures(this ToDoDbContext context)
        {
            context.ToDoLists.AddRange(new ToDoList[] {
               new ToDoList { Title = "To do first", Items = new List<ToDoItem> {
                   new ToDoItem { Title = "My first item" },
                   new ToDoItem { Title = "My second item" },
                   new ToDoItem { Title = "My third item" },
                   new ToDoItem { Title = "My fourth item" },
                   new ToDoItem { Title = "My fifth item" },
               }},

               new ToDoList { Title = "To do second", Items = new List<ToDoItem> {
                   new ToDoItem { Title = "My first item" },
                   new ToDoItem { Title = "My second item" },
                   new ToDoItem { Title = "My third item" },
                   new ToDoItem { Title = "My fourth item" },
                   new ToDoItem { Title = "My fifth item" },
               }},

               new ToDoList { Title = "To do third", Items = new List<ToDoItem> {
                   new ToDoItem { Title = "My first item" },
                   new ToDoItem { Title = "My second item" },
                   new ToDoItem { Title = "My third item" },
                   new ToDoItem { Title = "My fourth item" },
                   new ToDoItem { Title = "My fifth item" },
               }},

               new ToDoList { Title = "To do fourth", Items = new List<ToDoItem> {
                   new ToDoItem { Title = "My first item" },
                   new ToDoItem { Title = "My second item" },
                   new ToDoItem { Title = "My third item" },
                   new ToDoItem { Title = "My fourth item" },
                   new ToDoItem { Title = "My fifth item" },
               }}
            });

            context.SaveChanges();
        }
    }
}
