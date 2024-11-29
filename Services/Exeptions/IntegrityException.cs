namespace BookStore.Services.Exeptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string? message) : base(message)
        {
        }
    }
}
