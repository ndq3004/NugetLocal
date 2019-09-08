using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuGetGallery
{
    public class PackageToDownload
    {
        public string PackageToDownloadId { get; set; }
        public string PackageToDownloadVersion { get; set; }
        public bool Exist { get; set; }
        public string ErrorsDownloadDependencies { get; set; }
    }
}