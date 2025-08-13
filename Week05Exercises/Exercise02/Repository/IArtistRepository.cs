using Ct.Ai.Models;
using Ct.Ai.Repositories;
namespace Ct.Ai.Repositories;

public interface IArtistRepository
{   


    // Deze methode haalt de artiest op aan de hand van zijn Id.
// Omdat het een Task<Artist> teruggeeft, betekent dit dat het resultaat
// pas later beschikbaar is (async) en dat we het moeten 'awaiten' bij gebruik.

    Task<List<Artist>> GetArtists();

   // Deze methode haalt de concerts op aan de hand van zijn Id.
// Omdat het een Task<Concert> teruggeeft, betekent dit dat het resultaat
// pas later beschikbaar is (async) en dat we het moeten 'awaiten' bij gebruik
   
    Task<List<Concert>> GetConcerts();

   


// Deze methode haalt alle Concert op die bij een bepaalde Artist horen.
// Task<List<Concert>> betekent dat we een lijst van concerts krijgen,
// maar pas zodra de async operatie (bv. database- of API-oproep) is afgerond.
    Task<List<Concert>> GetConcertForArtist(int ArtistID);






    

}

