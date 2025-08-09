using System.Collections.Generic;     // Voor List<T>
using System.Threading.Tasks;         // Voor Task<>
using Ct.Ai.Models;                   // Voor Post en Comment
using Ct.Ai.Repositories;             // Voor IPostRepository en PostRepository
using Ct.Ai.Service;                   // Voor ITodoApplicationService

namespace Ct.Ai.Service
{
    /// <summary>
    /// De concrete implementatie van ITodoApplicationService.
    /// Deze service praat met de PostRepository om data op te halen of te versturen.
    /// </summary>
    public class TodoApplicationService : ITodoApplicationService
    {
        // Veld dat verwijst naar de repository voor Posts.
        private readonly IPostRepository _postRepository;

        /// <summary>
        /// Constructor - wordt aangeroepen wanneer je een TodoApplicationService maakt.
        /// Hier wordt een PostRepository instantie aangemaakt en opgeslagen in _postRepository.
        /// </summary>
        public TodoApplicationService()
        {
            _postRepository = new PostRepository();
        }

        /// <summary>
        /// Haalt alle posts op via de repository.
        /// De '=>' syntax betekent een korte methode die direct de repository aanroept.
        /// await zorgt ervoor dat we wachten tot de async operatie klaar is.
        /// </summary>
        public async Task<List<Post>> GetPosts()
        {
            return await _postRepository.GetPosts();
        }

        /// <summary>
        /// Haalt een enkele post op aan de hand van een Id.
        /// _postRepository.GetPostById(Id) doet het echte werk, deze service roept dat aan.
        /// await zorgt dat het resultaat wordt teruggegeven zodra het klaar is.
        /// </summary>
        public async Task<Post> GetPostById(int Id)
        {
            return await _postRepository.GetPostById(Id);
        }

        /// <summary>
        /// Voegt een nieuwe post toe via de repository.
        /// Het resultaat is de aangemaakte Post (mogelijk met een nieuw Id van de server).
        /// </summary>
        public async Task<Post> AddPost(Post post)
        {
            return await _postRepository.AddPost(post);
        }

        /// <summary>
        /// Haalt alle comments op die horen bij een specifieke post (Id).
        /// Wacht op de repository en geeft de lijst met comments terug.
        /// </summary>
        public async Task<List<Comment>> GetCommentsForPost(int Id)
        {
            return await _postRepository.GetCommentsForPost(Id);
        }
    }
}
