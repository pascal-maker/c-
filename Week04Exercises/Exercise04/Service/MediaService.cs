using Ct.Ai.Models;
using Ct.Ai.Repositories;
namespace Ct.Ai.Services
{


    public class MediaService
    {
        private readonly IMediaRepository _repo;


        public MediaService(IMediaRepository repo)
        {
            _repo = repo;
        }

        public void Add(IMedia media)
        {
            if (string.IsNullOrWhiteSpace(media.Title))
               throw new ArgumentException("Title is required");
           _repo.Add(media);
        }

        
        public IMedia GetByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return null;
            return _repo.Get(title);
        }


        public List<IMedia> GetAll()
        {
            // Eventueel extra logica, maar hier volstaat:
            return _repo.GetAll();
        }



    }
}