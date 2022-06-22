using System.Web.Http;
using WebActivatorEx;
using Exam.EntityFramework.API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Exam.EntityFramework.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
              .EnableSwagger(c =>
              {
                  c.SingleApiVersion("v1", "First WEB API Demo");
                  c.IncludeXmlComments(string.Format(@"{0}\bin\FirstWebAPIDemo.XML",
                                       System.AppDomain.CurrentDomain.BaseDirectory));
              })
              .EnableSwaggerUi();
        }
    }
}