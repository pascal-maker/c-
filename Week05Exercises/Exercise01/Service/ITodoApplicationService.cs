using System.Collections.Generic;
using System.Threading.Tasks;
using Ct.Ai.Models;
using Ct.Ai.Repositories;
using Ct.Ai.Service;

namespace Ct.Ai.Service
{
    /// <summary>
    /// ITodoApplicationService - Interface voor de service layer
    /// Definieert het contract voor business logic operaties met posts en comments
    /// Volgt het Interface Segregation Principle van SOLID
    /// </summary>
    public interface ITodoApplicationService
    {
        /// <summary>
        /// Haalt alle posts op uit de externe API
        /// Async methode voor niet-blokkerende I/O operaties
        /// </summary>
        /// <returns>Lijst van alle beschikbare posts</returns>
        Task<List<Post>> GetPosts();

        /// <summary>
        /// Haalt een specifieke post op basis van ID op
        /// Async methode voor het ophalen van individuele posts
        /// </summary>
        /// <param name="id">Het unieke ID van de post</param>
        /// <returns>De gevonden post of null als niet gevonden</returns>
        Task<Post> GetPostById(int id);

        /// <summary>
        /// Voegt een nieuwe post toe aan de externe API
        /// Async methode voor het versturen van data naar server
        /// </summary>
        /// <param name="post">Het post object om toe te voegen</param>
        /// <returns>De toegevoegde post met server-generated ID</returns>
        Task<Post> AddPost(Post post);

        /// <summary>
        /// Haalt alle comments op voor een specifieke post
        /// Async methode voor het ophalen van gerelateerde data
        /// </summary>
        /// <param name="id">Het ID van de post waarvan comments opgehaald moeten worden</param>
        /// <returns>Lijst van comments voor de opgegeven post</returns>
        Task<List<Comment>> GetCommentsForPost(int id);
    }
}
