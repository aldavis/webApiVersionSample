using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http.Routing;

namespace webApiVersionSample.Versioning
{
    public class VersionConstraint : IHttpRouteConstraint
    {
        public const string VersionHeaderName = "api-version";

        private const int DefaultVersion = 1;

        public VersionConstraint(int allowedVersion)
        {
            AllowedVersion = allowedVersion;
        }

        public int AllowedVersion { get; }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            if (routeDirection != HttpRouteDirection.UriResolution) return true;

            if (VersionEnforcer.Versions[request.Method].ContainsKey(route.RouteTemplate))
            {
                return VersionEnforcer.Versions[request.Method][route.RouteTemplate] == AllowedVersion;
            }

            var version = GetVersionHeader(request) ?? GetVersionFromCustomContentType(request);

            return (version ?? DefaultVersion) == AllowedVersion;
        }

        private int? GetVersionFromCustomContentType(HttpRequestMessage request)
        {
            var mediaTypes = request.Headers.Accept.Select(h => h.MediaType);

            var regEx = new Regex(@"application\/vnd\.sampleApp\.v([\d]+)\+json");

            string matchingMediaType = mediaTypes.FirstOrDefault(mediaType => regEx.IsMatch(mediaType));

            if (matchingMediaType == null)
                return null;

            var m = regEx.Match(matchingMediaType);
            var versionAsString = m.Groups[1].Value;

            int version;
            if (int.TryParse(versionAsString, out version))
                return version;

            return null;
        }


        private int? GetVersionHeader(HttpRequestMessage request)
        {
            var versionAsString = string.Empty;
            IEnumerable<string> headerValues;

            if (request.Headers.TryGetValues("api-version", out headerValues) && headerValues.Count() == 1)
                versionAsString = headerValues.First();
            else
            {
                var accept = request.Headers.Accept.Where(a => a.Parameters.Count(p => p.Name == "version") > 0).ToList();

                if (accept.Any())
                    versionAsString = accept.First().Parameters.Single(s => s.Name == "version").Value;
            }

            int version;

            if (!string.IsNullOrEmpty(versionAsString) && int.TryParse(versionAsString, out version))
                return version;

            return null;
        }
    }
}