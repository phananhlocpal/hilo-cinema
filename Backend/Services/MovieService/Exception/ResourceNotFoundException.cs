namespace MovieService.Exception
{
    public class ResourceNotFoundException : IOException
    {
        public ResourceNotFoundException(string message) : base(message) { }
    }
}
