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
    }
}