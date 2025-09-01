// Import the System.Runtime.CompilerServices namespace for compiler services
// Import the media models namespace to use IMedia interface
using media.models;
// Import the media repositories namespace to use IMediaRepository interface
using media.Repositories;

// Define the namespace for media services
namespace media.Services
{
    /// <summary>
    /// MediaService - Service klasse voor business logic van media operaties
    /// Implementeert het Service Layer Pattern voor scheiding van business logic en data toegang
    /// Gebruikt Dependency Injection voor losse koppeling met repository
    /// </summary>
    public class MediaService
    {
        /// <summary>
        /// Repository dependency voor data toegang
        /// Private readonly voor immutability en dependency injection
        /// </summary>
        private readonly IMediaRepository _repo;

        /// <summary>
        /// Constructor voor dependency injection van repository
        /// Initialiseert de service met een repository implementatie
        /// </summary>
        /// <param name="repo">Repository implementatie voor data toegang</param>
        public MediaService(IMediaRepository repo)
        {
            // Wijs de opgegeven repository toe aan de private field
            _repo = repo;
        }

        /// <summary>
        /// Voegt een nieuw media item toe met validatie
        /// Business logic: controleert of titel geldig is voordat toevoegen
        /// </summary>
        /// <param name="media">Het media object om toe te voegen</param>
        /// <exception cref="ArgumentException">Wordt gegooid als titel ongeldig is</exception>
        public void Add(IMedia media)
        {
            // Valideer dat de media titel niet null, leeg of alleen whitespace is
            if (string.IsNullOrWhiteSpace(media.Title))
            {
                // Gooi exception als titel ongeldig is
                throw new ArgumentException("Title is required");
            }
            
            // Voeg het media item toe aan de repository als validatie slaagt
            _repo.Add(media);
        }

        /// <summary>
        /// Haalt een media item op basis van titel op met validatie
        /// Business logic: controleert of zoekterm geldig is
        /// </summary>
        /// <param name="title">Titel om naar te zoeken</param>
        /// <returns>Media object of null als niet gevonden</returns>
        public IMedia GetByTitle(string title)
        {
            // Return null als titel null, leeg of alleen whitespace is
            if (string.IsNullOrWhiteSpace(title)) return null;
            
            // Haal het media item op uit de repository
            return _repo.Get(title);
        }

        /// <summary>
        /// Haalt alle media items op uit de repository
        /// Business logic: geen extra validatie nodig, direct doorgeven aan repository
        /// </summary>
        /// <returns>Lijst van alle media objecten</returns>
        public List<IMedia> GetAll()
        {
            // Return alle media items uit de repository
            return _repo.GetAll();
        }
    }
}
