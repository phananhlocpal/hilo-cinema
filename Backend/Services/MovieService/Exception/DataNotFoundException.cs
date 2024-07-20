namespace MovieService.Exception
{
    public class DataNotFoundException : IOException
    {
        public DataNotFoundException(string message)  : base(message) { }
    }
}
