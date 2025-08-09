using System.Collections.Generic;     // Voor List<T>
using System.Threading.Tasks;         // Voor Task<>
using Ct.Ai.Models;                   // Voor Post en Comment
// using Ct.Ai.Repositories;          // Alleen nodig in de implementatie, niet voor de interface
// using Ct.Ai.Service;               // Niet nodig hier; zie namespace hieronder

namespace Ct.Ai.Service
{
    /// <summary>
    /// Service-laag voor het werken met Posts en hun Comments.
    /// Async (Task/await) zodat IO-werk (HTTP/DB) niet blokkeert.
    /// </summary>
    public interface ITodoApplicationService
    {
        /// <summary>
        /// Haal ALLE posts op.
        /// Task<List<Post>> = "er komt later een lijst met posts" (async resultaat).
        /// </summary>
        Task<List<Post>> GetPosts();

        /// <summary>
        /// Haal één post op aan de hand van zijn ID.
        /// Retourneert een enkele Post (dus géén List).
        /// </summary>
        Task<Post> GetPostById(int Id);

        /// <summary>
        /// Voeg een nieuwe post toe en geef de aangemaakte post terug
        /// (incl. eventueel nieuw toegekend Id van de server).
        /// </summary>
        Task<Post> AddPost(Post post);

        /// <summary>
        /// Haal alle comments op die bij een bepaalde post horen.
        /// </summary>
        Task<List<Comment>> GetCommentsForPost(int Id);
    }
}
