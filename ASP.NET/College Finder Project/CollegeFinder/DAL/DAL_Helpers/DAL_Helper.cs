namespace CollegeFinder.DAL.DAL_Helpers
{
    public class DAL_Helper
    {
        public static string ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyConnectionString");
    }
}
