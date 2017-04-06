using System.Collections.Generic;
using System.Web.Http.Routing;

namespace webApiVersionSample.Versioning
{
    public class VersionedRoute : RouteFactoryAttribute
    {
        public VersionedRoute(string template, int allowedVersion): base(template)
        {
            AllowedVersion = allowedVersion;
        }

        public int AllowedVersion { get; }

        public override IDictionary<string, object> Constraints
        {
            get
            {
                var constraints = new HttpRouteValueDictionary
                {
                    {"version", new VersionConstraint(AllowedVersion)}
                };

                return constraints;
            }
        }
    }
}