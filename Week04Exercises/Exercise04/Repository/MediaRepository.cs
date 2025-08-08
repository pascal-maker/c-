using Ct.Ai.Models;
using System.Globalization;
using Ct.Ai.Repositories;
namespace Ct.Ai.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private static readonly List<IMedia> _store = new();

        public void Add(IMedia media)

      {
        if (_store.Any(m => m.Title.Equals(media.Title, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"Media with title '{media.Title}' already exists");
        _store.Add(media);
      }

        public IMedia Get(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return null;
            var key = title.Trim();
            return _store.FirstOrDefault(m =>
                m.Title.Equals(key, StringComparison.OrdinalIgnoreCase));
        }
        
        //“Take the title the user gave me, trim extra spaces, then search the _store list for the first media whose title matches that trimmed string, ignoring case. Return that media, or null if not found.”


        

      public List<IMedia> GetAll()
      {
       return _store.ToList();
      }





   }
}


