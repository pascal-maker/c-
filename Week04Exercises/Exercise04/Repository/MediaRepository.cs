// Import the media models namespace to use IMedia interface
using media.models;

// Define the namespace for media repositories
namespace media.Repositories
{
    /// <summary>
    /// MediaRepository - Concrete implementatie van IMediaRepository
    /// Implementeert data toegang voor media objecten met in-memory storage
    /// Volgt het Repository Pattern voor scheiding van data toegang en business logic
    /// </summary>
    public class MediaRepository : IMediaRepository
    {
        /// <summary>
        /// In-memory storage voor alle media items
        /// Static readonly lijst die wordt gedeeld door alle instanties
        /// </summary>
        private static readonly List<IMedia> _store = new();

        /// <summary>
        /// Voegt een nieuw media item toe aan de repository
        /// Controleert op duplicaten op basis van titel (case-insensitive)
        /// </summary>
        /// <param name="media">Het media object om toe te voegen</param>
        /// <exception cref="InvalidOperationException">Wordt gegooid als titel al bestaat</exception>
        public void Add(IMedia media)
        {
            // Controleer of er al een media item bestaat met dezelfde titel (case-insensitive)
            if (_store.Any(m => m.Title.Equals(media.Title, StringComparison.OrdinalIgnoreCase)))
            {
                // Gooi exception als titel al bestaat
                throw new InvalidOperationException($"Media with title '{media.Title}' already exists");
            }
            
            // Voeg het media item toe aan de store als titel uniek is
            _store.Add(media);
        }

        /// <summary>
        /// Haalt een media item op basis van titel op
        /// Zoekt case-insensitive en handelt null/empty input af
        /// </summary>
        /// <param name="title">Titel van het media item om te zoeken</param>
        /// <returns>Media object of null als niet gevonden</returns>
        public IMedia Get(string title)
        {
            // Return null als titel null, leeg of alleen whitespace is
            if (string.IsNullOrWhiteSpace(title)) return null;
            
            // Trim whitespace van de titel
            var key = title.Trim();
            
            // Zoek het eerste media item dat overeenkomt met de titel (case-insensitive)
            return _store.FirstOrDefault(m => m.Title.Equals(key, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Haalt alle media items op uit de repository
        /// Return een nieuwe lijst om de originele lijst te beschermen
        /// </summary>
        /// <returns>Lijst van alle media objecten</returns>
        public List<IMedia> GetAll()
        {
            // Return een nieuwe lijst met alle media items uit de store
            return _store.ToList();
        }
    }
}