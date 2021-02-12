using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsTodo.Models;

namespace XamarinFormsTodo.Services
{
    public interface ITodoService
    {
        string SupabaseUrl { get; }
        string SupabaseKey { get; }

        /// <summary>
        /// Get all todos
        /// </summary>
        /// <returns></returns>
        Task<List<TodoItem>> GetItemsAsync();

        /// <summary>
        /// Get todos not done yet
        /// </summary>
        /// <returns></returns>
        Task<List<TodoItem>> GetItemsNotDoneAsync();

        /// <summary>
        /// Get todo by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TodoItem> GetItemAsync(int id);

        /// <summary>
        /// Add new todo to database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> SaveItemAsync(TodoItem item);

        /// <summary>
        /// Delete todo from database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> DeleteItemAsync(TodoItem item);
    }
}
