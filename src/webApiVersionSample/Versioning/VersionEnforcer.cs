using System.Collections.Generic;
using System.Net.Http;

namespace webApiVersionSample.Versioning
{
    public class VersionEnforcer
    {
        private static Dictionary<HttpMethod, Dictionary<string, int>> _versions;

        public static Dictionary<HttpMethod, Dictionary<string, int>> Versions
        {
            get
            {
                if (_versions == null)
                {
                    InitializeVersionDictionary();
                }

                return _versions;
            }
        }

        private static void InitializeVersionDictionary()
        {

            _versions = new Dictionary<HttpMethod, Dictionary<string, int>>
            {
                {
                    HttpMethod.Get, new Dictionary<string, int>
                    {
                        {"api/products/listing",1 }
                    }

                },
                {
                    HttpMethod.Post, new Dictionary<string, int>
                    {
                        {"api/products/add",1 },
                        {"api/products/categories/add",1 }
                    }
                }
            };
        }
    }
}