using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuGetGallery.RequestModels
{
    public class PostPackageInfo
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public PostPackageInfo()
        {
            Id = "";
            Version = null;
        }
        public PostPackageInfo(string id, string version)
        {
            Id = id;
            Version = version;
        }
    }
}