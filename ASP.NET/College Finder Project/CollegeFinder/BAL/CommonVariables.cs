namespace CollegeFinder.BAL
{
    public class CommonVariables
    {
        public static IHttpContextAccessor _httpContextAccessor;

        static CommonVariables()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public static int? UserID()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                return Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserID").ToString());
            }
            return null;
        }
        public static string? Username()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("Username") != null)
            {
                return _httpContextAccessor.HttpContext.Session.GetString("Username").ToString();
            }
            return null;
        }

        public static Boolean IsAdmin()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("IsAdmin") != null)
            {
                return Convert.ToBoolean(_httpContextAccessor.HttpContext.Session.GetString("IsAdmin")) ? true : false;
            }
            return false;
        }
    }
}
