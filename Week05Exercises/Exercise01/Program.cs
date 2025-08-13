using System;                         // Nodig voor Console.WriteLine, enz.
using System.Threading.Tasks;         // Nodig voor Task<> en async/await
using Ct.Ai.Models;                   // Toegang tot Post en Comment klassen
using Ct.Ai.Service;                  // Toegang tot TodoApplicationService interface & implementatie

public class Posts
{
    // Main is het startpunt van de applicatie
    // async Task zorgt ervoor dat we await kunnen gebruiken in Main
    public static async Task Main(string[] args)
    {
        // Maak de service aan die met de API praat (onder water via PostRepository)
        var todoService = new TodoApplicationService();

        // -------------------- ALLE POSTS OPHALEN --------------------
        Console.WriteLine("\nFetching all posts..");  // Laat weten wat er gebeurt
        var posts = await todoService.GetPosts();     // Wacht async tot alle posts zijn opgehaald
        foreach (var post in posts)                   // Loop door elke post in de lijst
            Console.WriteLine(post);                  // Toont de post (via ToString())

        // -------------------- POST OP ID OPHALEN --------------------
        Console.WriteLine("\nFetching post with ID 1..."); // Duidelijkere tekst dan "all posts"
        var singlePost = await todoService.GetPostById(1); // Haalt één specifieke post op
        Console.WriteLine(singlePost);                     // Toont deze ene post

        // -------------------- NIEUWE POST TOEVOEGEN --------------------
        Console.WriteLine("\nAdding a new post");           // Statusbericht
        var newPost = new Post                              // Maak nieuw Post-object
        {
            UserId = 1,                                     // ID van gebruiker
            Title = "New Post",                             // Titel van de post
            Body = "This is a new post"                     // Inhoud van de post
        };
        var addedPost = await todoService.AddPost(newPost); // Stuur nieuwe post naar API
        Console.WriteLine($"New post added: {addedPost}");  // Toon de toegevoegde post

        // -------------------- COMMENTS VAN POST --------------------
        Console.WriteLine("\nFetching comments for post ID 1..."); // Statusbericht
        var comments = await todoService.GetCommentsForPost(1);    // Haal alle comments van post 1
        foreach (var c in comments)                                // Loop door comments
            Console.WriteLine(c);                                  // Toont elke comment
    }
}
