// Import System.Collections.Generic for List<T> functionality
using System.Collections.Generic;
// Import System.Threading.Tasks for async/await functionality
using System.Threading.Tasks;
// Import custom models for Post and Comment classes
using Ct.Ai.Models;

// Define the namespace for service implementations
namespace Ct.Ai.Service
{
    // Define the TodoApplicationService class that implements ITodoApplicationService interface
    public class TodoApplicationService : ITodoApplicationService
    {
        // Private field to store the post repository dependency
        private IPostRepository _postRepository;

        // Constructor to initialize the service with a new repository instance
        public TodoApplicationService()
        {
            // Create a new PostRepository instance for data access
            _postRepository = new PostRepository();
        }

        // Implementation of GetPosts method to retrieve all posts
        public async Task<List<Post>> GetPosts()
        {
            // Delegate the call to the repository and return the result
            return await _postRepository.GetPosts();
        }

        // Implementation of GetPostById method to retrieve a specific post by ID
        public async Task<Post> GetPostById(int Id)
        {
            // Delegate the call to the repository and return the result
            return await _postRepository.GetPostById(Id);
        }

        // Implementation of AddPost method to add a new post
        public async Task<Post> AddPost(Post post)
        {
            // Delegate the call to the repository and return the result
            return await _postRepository.AddPost(post);
        }

        // Implementation of GetCommentsForPost method to retrieve comments for a specific post
        public async Task<List<Comment>> GetCommentsForPost(int id)
        {
            // Delegate the call to the repository and return the result
            return await _postRepository.GetCommentsForPost(id);
        }

        // Empty line for spacing

        // Empty line for spacing

        // Empty line for spacing

        // Empty line for spacing

        // Empty line for spacing

        // Empty line for spacing

    }
}