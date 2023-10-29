namespace Audote.Server.Domain.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public Stream? Data { get; set; }
        public int AnimalId { get; set; }
    }
}
