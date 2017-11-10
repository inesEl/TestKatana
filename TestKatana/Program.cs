using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKatana
{
    using AppFunc = Func<IDictionary<string, Object>, Task>;
    class Program
    {
        public static void Main(string[] args)
        {
            string Uri = "http://localhost:8080";
            WebApp.Start<Startup>(Uri);
            Console.ReadKey();
        }
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.Use<HelloWolrdComponenet>();
                //app.Run(ctx =>
                //{
                //    return ctx.Response.WriteAsync("Hell yeah");

                //});
            }

        }

        public class HelloWolrdComponenet
        {
            AppFunc _next;
            public HelloWolrdComponenet(AppFunc next)
            {
                _next = next;
            }
            public Task Invoke (IDictionary<string,Object> environment)
            {
                var response = environment["owin.ResponseBody"] as Stream;
                using (var writer = new StreamWriter(response))
                {

                    return writer.WriteAsync("youhououuu Biiiitch");
                }

            }
        }
    }
}
