using System;
using System.Linq;
using System.Text;

namespace UsagiConnect.Client
{
    public class Route
    {
        /* ENDPOINTS */
        public static Route BEATMAP = new(Method.GET, "beatmaps/{beatmap_id}");
        public static Route BEATMAP_ATTRIBUTES = new(Method.POST, "beatmaps/{beatmap_id}/attributes");
        public static Route USER = new(Method.GET, "users/{user}/{mode}");

        private readonly Method method;
        private readonly string route;
        private readonly int paramsCount;

        public enum Method
        {
            GET, POST
        }

        public Route(Method method, string route)
        {
            this.method = method;
            this.route = route;
            this.paramsCount = (int)route.Count(c => c == '{');
            if (route.Count(c => c == '}') != paramsCount)
                throw new ArgumentException("Error occured with " + route);
        }

        public string Compile(params string[] parameters)
        {
            if (parameters.Length != paramsCount)
                throw new ArgumentException(string.Format("Expected {0} params: {1}", paramsCount, route));
            StringBuilder compiledRoute = new StringBuilder(route);
            foreach (string param in parameters)
            {
                compiledRoute.Replace(compiledRoute.ToString().Substring(compiledRoute.ToString().IndexOf("{"), compiledRoute.ToString().IndexOf("}") - compiledRoute.ToString().IndexOf("{") + 1), param);
            }
            return compiledRoute.ToString();
        }
    }
}