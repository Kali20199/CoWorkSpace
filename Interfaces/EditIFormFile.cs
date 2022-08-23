namespace CoWorkSpace.Interfaces
{

    #nullable enable
    public class EditIFormFile : IFormFile
    {
        public string ContentType  { get; }

        public string ContentDisposition  { get; }

        public IHeaderDictionary Headers  { get; }

        public long Length  { get; }

        public string Name  { get; }

        public string FileName  { get; }

        public void CopyTo(Stream target)
        {
            throw new NotImplementedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Stream OpenReadStream()
        {
            throw new NotImplementedException();
        }
    }
}