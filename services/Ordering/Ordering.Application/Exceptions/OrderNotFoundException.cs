namespace Ordering.Application.Exceptions
{
    public class OrderNotFoundException : ApplicationException
    {
        public OrderNotFoundException(string name , Object Key):base($"Entity {name} - {Key} isn't found")
        {             
        }
    }
}
