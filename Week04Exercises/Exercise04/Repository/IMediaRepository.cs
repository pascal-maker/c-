using Ct.Ai.Models;
using Ct.Ai.Repositories;
namespace Ct.Ai.Repositories
{
    public interface IMediaRepository
    {
        void Add(IMedia media);
        IMedia Get(string title);
        List<IMedia> GetAll();

    }
}
