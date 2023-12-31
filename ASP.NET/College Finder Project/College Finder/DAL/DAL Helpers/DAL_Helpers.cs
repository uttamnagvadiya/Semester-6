namespace College_Finder.DAL
{
    public class DAL_Helpers
    {
        public static string ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyConnectionString");
    }
}
