namespace Labolatorium_3_App.Models
{
    public class LastVisitCookie
    {
        private readonly RequestDelegate _delegate;
        public static readonly string CookieName = "visit";
        public LastVisitCookie(RequestDelegate @delegate)
        {
            _delegate = @delegate;
        }

        public async Task Invoke(HttpContext context)
        {
            
            if (context.Request.Cookies.ContainsKey(CookieName))
            {
               string? visit = context.Request.Cookies[CookieName];
                if (visit != null) 
                {
                    if (DateTime.TryParse(visit, out var lastVisitDate))
                    {
                        context.Items[CookieName] = lastVisitDate;

                    }
                }
            }
            else
            {
                context.Items[CookieName] = "First visit";
            }
            context.Response.Cookies.Append(CookieName, DateTime.Now.ToString());
            await _delegate(context);
        }
    }
}
