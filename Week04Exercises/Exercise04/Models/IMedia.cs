namespace Ct.Ai.Models
{
    public interface IMedia
    {
        string Title { get; }
        void Consume();  // common action (play/watch/listen)
    }
}
