namespace Product_Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new MongoDbConnection().CreateConnection();
        }
    }
}
