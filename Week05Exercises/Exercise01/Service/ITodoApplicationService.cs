// Import System.Collections.Generic for List<T> functionality
using System.Collections.Generic;
// Import System.Threading.Tasks for async/await functionality
using System.Threading.Tasks;
// Import custom models for Post and Comment classes
using Ct.Ai.Models;

// Define the namespace for service interfaces
namespace Ct.Ai.Service
{
    // Define the interface for todo application service operations
    public interface ITodoApplicationService
    {
        // Method to retrieve all posts asynchronously
        Task<List<Post>> GetPosts();

        // Method to retrieve a specific post by ID asynchronously
        Task<Post> GetPostById(int id);

        // Empty line for spacing

        // Method to add a new post asynchronously
        Task<Post> AddPost(Post post);

        // Method to retrieve all comments for a specific post asynchronously
        Task<List<Comment>> GetCommentsForPost(int id);
         
        // Empty line for spacing

        // Empty line for spacing

        // Empty line for spacing

        // Empty line for spacing

    }
    // Empty line for spacing

}
