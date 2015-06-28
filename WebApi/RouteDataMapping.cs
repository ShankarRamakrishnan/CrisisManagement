namespace WebApi
{
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;

    public class RouteDataMapping : MediaTypeMapping
    {
        public RouteDataMapping(string routeDataValueName, string routeDataValueValue, MediaTypeHeaderValue mediaType)
            : base(mediaType)
        {
            RouteDataValueName = routeDataValueName;
            RouteDataValueValue = routeDataValueValue;
        }

        public string RouteDataValueName { get; private set; }

        public string RouteDataValueValue { get; private set; }

        public override double TryMatchMediaType(HttpRequestMessage request)
        {
            if (request.GetRouteData().Values[RouteDataValueName] == null)
            {
                return 0.0;
            }

            return string.CompareOrdinal(
                    request.GetRouteData().Values[RouteDataValueName].ToString(),
                    RouteDataValueValue) == 0
                           ? 1.0
                           : 0.0;
        }
    }
}
