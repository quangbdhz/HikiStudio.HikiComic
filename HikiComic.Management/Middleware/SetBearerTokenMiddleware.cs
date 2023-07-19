namespace HikiComic.Management.Middleware
{
    public class SetBearerTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public SetBearerTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Cookies["TOKEN"];

            if(!String.IsNullOrEmpty(token))
                context.Request.Headers.Authorization = "Bearer " + token;

            //context.Response.Cookies.Append("TEST", "ABDBADA", new CookieOptions { HttpOnly = true, Secure = true, SameSite = SameSiteMode.Lax });

            await _next(context);
        }
    }
}
