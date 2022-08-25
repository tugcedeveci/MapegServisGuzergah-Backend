using Microsoft.AspNetCore.Mvc;

namespace MapegServisGuzergah.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected IHttpContextAccessor _httpContextAccessor;
        protected readonly long _userId;
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            if (_httpContextAccessor.HttpContext.Request != null)
            {
                var values = _httpContextAccessor.HttpContext.Request.Headers["userId"];
                if (!string.IsNullOrEmpty(values))
                {
                    _userId = Convert.ToInt64(values);
                }
            }
        }
    }
}
