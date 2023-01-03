using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Aspects.Secured
{
    public class SecuredAspect:MethodInterception
    {
        private IHttpContextAccessor _httpContextAccessor;
        public SecuredAspect()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnAfter(IInvocation invocation)
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            if (claims.Count() > 0)
            {
                return;
            }
        }
    }
}
