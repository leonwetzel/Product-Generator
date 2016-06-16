namespace Product_Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connection = new MongoDbConnection();
            connection.CreateConnection();
        }
    }
}
