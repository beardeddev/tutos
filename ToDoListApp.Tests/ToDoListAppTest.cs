using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoListApp.Models;
using Xunit;

namespace ToDoListApp.Tests
{
    public class ToDoListAppTest : IClassFixture<ToDoListApplicationFactory<Startup>>
    {
        private readonly ToDoListApplicationFactory<Startup> _factory;

        // Arrange
        public ToDoListAppTest(ToDoListApplicationFactory<Startup> factory)
        {
            this._factory = factory;
        }

        [Theory]
        [InlineData("/api/v1/todolists/")]
        [InlineData("/api/v1/todoitems/")]
        public async Task Get_Entities_ReturnSuccessAndCorrectContentType(string url)
        {
            //Arrange
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/v1/todolists/1")]
        [InlineData("/api/v1/todoitems/1")]
        public async Task Get_Entity_ReturnSuccessAndCorrectContentType(string url)
        {
            //Arrange
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();            

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/v1/todolists/")]
        public async Task Post_ToDoList_ReturnCreatedAndCorrectEntityId(string url)
        {
            HttpClient client = _factory.CreateClient();

            ToDoList todoList = new ToDoList
            {
                Title = "My third list",
                Items = new List<ToDoItem>(),
            };

            String json = JsonSerializer.Serialize<ToDoList>(todoList);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            String responseBody = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            ToDoList toDoList = JsonSerializer.Deserialize<ToDoList>(responseBody, options);

            Assert.NotEqual(0, toDoList.Id);
        }

        [Theory]
        [InlineData("/api/v1/todolists/3", "To do third (updated)")]
        public async Task Put_ToDoList_ReturnSuccessAndCorrectContentType(string url, string title)
        {
            HttpClient client = _factory.CreateClient();

            ToDoList todoList = new ToDoList
            {
                Id = 3,
                Title = title,
                Items = new List<ToDoItem>(),
            };

            String json = JsonSerializer.Serialize<ToDoList>(todoList);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);

            response.EnsureSuccessStatusCode();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/v1/todolists/4")]
        public async Task Delete_ToDoList_ReturnSuccess(string url)
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
