namespace Ct.Ai.Models
{
    public static class MediaFactory
    {
        public static IMedia Create(string mediaType)
        {
            switch (mediaType.ToLowerInvariant())
            {
                case "movie":   return new Movie("Harry Potter", 152, "sci-fi", "James Cameron");
                case "series":  return new Series("Prison Break", 90, "drama", "FOX");
                case "podcast": return new Podcast("The Joe Rogan Experience", 2400, "Joe Rogan");
                default: throw new ArgumentException("Unknown media type");
            }
        }
    }
}
