namespace DIObject
{

    public class ObjectMessage : IObjectMessage
    {
        public string Display()
        {
            return "Interception sample using Unity Interceptor extension";
        }
    }

    public interface IObjectMessage
    {
        string Display();
    }
}
