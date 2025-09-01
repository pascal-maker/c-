using System;

using System.Threading.Tasks;

using Ct.Ai.Models;

using Ct.Ai.Service;

/// <summary>
/// Posts - Hoofdklasse voor de Todo Application
/// Demonstreert het gebruik van async/await pattern en service layer architecture
/// Communiceert met externe JSON API via HTTP requests
/// </summary>
public class Posts
{
    /// <summary>
    /// Main methode - Entry point van de applicatie
    /// Async methode voor het demonstreren van asynchrone operaties
    /// </summary>
    /// <param name="args">Command line arguments (niet gebruikt in deze applicatie)</param>
    public static async Task Main(string[] args)
    {
        // Maak een nieuwe service instantie aan
        // Service layer zorgt voor business logic en data toegang
        var todoapplicationService = new TodoApplicationService();

        // ========================================
        // OPERATIE 1: Alle posts ophalen
        // ========================================
        Console.WriteLine("\nFetching all posts...");
        
        // Async call: wacht niet op I/O, laat andere taken toe
        var posts = await todoapplicationService.GetPosts();
        
        // Itereer door alle posts en toon ze
        foreach (var post in posts)
            Console.WriteLine(post);

        // ========================================
        // OPERATIE 2: Specifieke post ophalen
        // ========================================
        Console.WriteLine("\nFetching post with id 1");
        
        // Haal post met ID 1 op via service layer
        var singlePost = await todoapplicationService.GetPostById(1);
        
        // Toon de gevonden post
        Console.WriteLine(singlePost);  

        // ========================================
        // OPERATIE 3: Nieuwe post toevoegen
        // ========================================
        Console.WriteLine("\nAdding a new post");
        
        // Maak een nieuw Post object aan met object initializer syntax
        var newPost = new Post
        {
            UserId = 1,                    // ID van de gebruiker
            Title = "New Post",            // Titel van de post
            Body = "This is a new post"    // Inhoud van de post
        };
        
        // Voeg de nieuwe post toe via service layer
        var addedPost = await todoapplicationService.AddPost(newPost);
        
        // Toon bevestiging van toegevoegde post
        Console.WriteLine($"New post added: {addedPost}");

        // ========================================
        // OPERATIE 4: Comments ophalen
        // ========================================
        Console.WriteLine("\nFetching comments for post id 1.....");
        
        // Haal alle comments op voor post met ID 1
        var comments = await todoapplicationService.GetCommentsForPost(1);
        
        // Itereer door alle comments en toon ze
        foreach (var c in comments)
            Console.WriteLine(c);
    }
}