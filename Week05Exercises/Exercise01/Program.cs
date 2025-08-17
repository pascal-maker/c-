// Import the System namespace for basic functionality
using System;
// Import the System.Threading.Tasks namespace for async/await functionality
using System.Threading.Tasks;
// Import the custom models namespace to use Post class
using Ct.Ai.Models;
// Import the custom service namespace to use TodoApplicationService
using Ct.Ai.Service;

// Define the Posts class to contain the main program
public class Posts
{
    // Define the main entry point as an async method
    public static async Task Main(string[] args)
    {
        // Create a new instance of TodoApplicationService for handling business logic
        var todoapplicationService = new TodoApplicationService();

        // Display a header for fetching all posts
        Console.WriteLine("\n Fetching all posts..");

        // Call the service to get all posts asynchronously
        var posts = await todoapplicationService.GetPosts();
        // Iterate through each post and display it
        foreach (var post in posts)
            Console.WriteLine(post);

        // Empty line for spacing

        // Display a header for fetching a specific post
        Console.WriteLine("\nfetching post with ID 1");
        // Call the service to get a post with ID 1 asynchronously
        var singlePost = await todoapplicationService.GetPostById(1);
        // Display the retrieved post
        Console.WriteLine(singlePost);

        // Empty line for spacing

        // Display a header for adding a new post
        Console.WriteLine("\nAdding a new post");
        // Create a new Post object with initial values
        var newPost = new Post
        {
            // Set the user ID to 1
            UserId = 1,
            // Set the title of the new post
            Title = " New post",
            // Empty line for spacing
            // Set the body content of the new post
            Body = "This a new post"
        };

        // Call the service to add the new post asynchronously
        var addedPost = await todoapplicationService.AddPost(newPost);
        // Display confirmation that the post was added
        Console.WriteLine($" New post added {addedPost}");

        // Empty line for spacing

        // Empty line for spacing

        // Display a header for fetching comments
        Console.WriteLine("\nFetching  Comments for post Id....");
        // Call the service to get comments for post with ID 1 asynchronously
        var comments = await todoapplicationService.GetCommentsForPost(1);

        // Iterate through each comment and display it
        foreach (var c in comments)
            Console.WriteLine(c);

        // Empty line for spacing

        // Empty line for spacing

        // Empty line for spacing

        // Empty line for spacing
        
    }
    
}

