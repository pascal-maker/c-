using System.Collections.Generic;
using System.Threading.Tasks;
using Ct.Ai.Models;
using Ct.Ai.Repositories;
using Ct.Ai.Service;

namespace Ct.Ai.Service
{
    /// <summary>
    /// TodoApplicationService - Service klasse voor het beheren van posts en comments
    /// Implementeert het Service Layer Pattern voor business logic
    /// Gebruikt async/await voor asynchrone operaties met externe API
    /// </summary>
    public class TodoApplicationService: ITodoApplicationService
    {
        // Dependency injection: service gebruikt repository voor data toegang
        // Private field voor loose coupling tussen service en repository
        private IPostRepository _postRepository;

        /// <summary>
        /// Constructor - Initialiseert de service met een nieuwe repository
        /// Dependency Injection: service krijgt repository als dependency
        /// </summary>
        public TodoApplicationService()
        {
            _postRepository = new PostRepository();
        }

        /// <summary>
        /// Haalt alle posts op uit de externe API
        /// Async methode: wacht niet op I/O operaties, laat andere taken toe
        /// </summary>
        /// <returns>Lijst van alle beschikbare posts</returns>
        public async Task<List<Post>> GetPosts()
        {
            // Delegate naar repository: service doet alleen business logic
            return await _postRepository.GetPosts();
        }

        /// <summary>
        /// Haalt een specifieke post op basis van ID op
        /// Async methode voor niet-blokkerende I/O operaties
        /// </summary>
        /// <param name="id">Het unieke ID van de post</param>
        /// <returns>De gevonden post of null als niet gevonden</returns>
        public async Task<Post> GetPostById(int id)
        {
            // Delegate naar repository voor data toegang
            return await _postRepository.GetPostById(id);
        }

        /// <summary>
        /// Voegt een nieuwe post toe aan de externe API
        /// Async methode voor het versturen van data naar server
        /// </summary>
        /// <param name="post">Het post object om toe te voegen</param>
        /// <returns>De toegevoegde post met server-generated ID</returns>
        public async Task<Post> AddPost(Post post)
        {
            // Delegate naar repository voor data opslag
            return await _postRepository.AddPost(post);
        }

        /// <summary>
        /// Haalt alle comments op voor een specifieke post
        /// Async methode voor het ophalen van gerelateerde data
        /// </summary>
        /// <param name="id">Het ID van de post waarvan comments opgehaald moeten worden</param>
        /// <returns>Lijst van comments voor de opgegeven post</returns>
        public async Task<List<Comment>> GetCommentsForPost(int id)
        {
            // Delegate naar repository voor data toegang
            return await _postRepository.GetCommentsForPost(id);
        }
    }
}