// Import the models namespace to use Post and Comment classes
using Ct.Ai.Models;
// Import the repositories namespace for interface definition
using Ct.Ai.Repositories;
// Define the namespace for repository interfaces
namespace Ct.Ai.Repositories;
// Define the interface for post repository operations
public interface IPostRepository
{
    // Method to retrieve all posts asynchronously
    Task<List<Post>> GetPosts();

    // Method to retrieve a specific post by ID asynchronously
    Task<Post> GetPostById(int id);

    // Method to add a new post asynchronously
    Task <Post> AddPost(Post post);

    // Method to retrieve all comments for a specific post asynchronously
    Task<List<Comment>> GetCommentsForPost(int id);

    // Empty line for spacing

    // Empty line for spacing

    // Empty line for spacing

    // Empty line for spacing

}
