using Postgrest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinFormsTodo.Models;

namespace XamarinFormsTodo.Services
{
    public class TodoService : ITodoService
    {

        public string SupabaseUrl => Environment.GetEnvironmentVariable("supabaseUrl");

        public string SupabaseKey => Environment.GetEnvironmentVariable("supabaseKey");

        private readonly Client _postgrestClient;

        public TodoService()
        {
            var clientOptions = new ClientOptions
            {
                Headers = new Dictionary<string, string>()
                {
                    { "apikey", SupabaseKey }
                }
            };
            _postgrestClient = Client.Initialize($"{SupabaseUrl}/rest/v1", clientOptions);
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            var todo = await GetItemAsync(item.Id);

            if (todo == null)
                return -1;

            await todo.Delete<TodoItem>();
            return todo.Id;
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            var todo = await _postgrestClient.Table<TodoItem>().Filter("id", Constants.Operator.Equals, id).Single();
            return todo;
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            var todos = await _postgrestClient.Table<TodoItem>().Get();
            return todos.Models;
        }

        public async Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            var todos = await _postgrestClient.Table<TodoItem>().Filter("done", Constants.Operator.Equals, false).Get();
            return todos.Models;
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            if(item.Id != 0)
            {
                var todo = await GetItemAsync(item.Id);
                todo.Name = item.Name;
                todo.Notes = item.Notes;
                todo.Done = item.Done;
                await todo.Update<TodoItem>();
                return todo.Id;
            }

            var response = await _postgrestClient.Table<TodoItem>().Insert(item);
            return response.Models.First().Id;
        }
            
    }
}
