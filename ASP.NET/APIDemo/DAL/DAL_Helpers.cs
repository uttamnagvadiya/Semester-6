namespace APIDemo.DAL
{
    public class DAL_Helpers
    {
        public static string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyConnectionString");
    }
}
