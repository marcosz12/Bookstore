namespace BookStore.Services.Exeptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string? message) : base(message) 
        {

        }
    }
}
