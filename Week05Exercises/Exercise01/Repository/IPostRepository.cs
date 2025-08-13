using Ct.Ai.Models;
using Ct.Ai.Repositories;
namespace Ct.Ai.Repositories;

public interface IPostRepository
{   


    // Deze methode haalt een Post op aan de hand van zijn Id.
// Omdat het een Task<Post> teruggeeft, betekent dit dat het resultaat
// pas later beschikbaar is (async) en dat we het moeten 'awaiten' bij gebruik.

    Task<List<Post>> GetPosts();

    // Deze methode voegt een nieuwe Post toe.
// Het resultaat is ook een Task<Post> zodat de aanroepende code kan wachten
// totdat de toevoeging klaar is en de toegevoegde Post wordt teruggegeven.
   
    Task<Post> GetPostById(int Id);

    // Deze methode voegt een nieuwe Post toe.
// Het resultaat is ook een Task<Post> zodat de aanroepende code kan wachten
// totdat de toevoeging klaar is en de toegevoegde Post wordt teruggegeven
    Task<Post> AddPost(Post post);


// Deze methode haalt alle Comments op die bij een bepaalde Post horen.
// Task<List<Comment>> betekent dat we een lijst van comments krijgen,
// maar pas zodra de async operatie (bv. database- of API-oproep) is afgerond.
    Task<List<Comment>> GetCommentsForPost(int Id);






    

}

