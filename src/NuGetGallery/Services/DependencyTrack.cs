using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using NuGet;
using NuGet.Services.Entities;

namespace NuGetGallery.Services
{
    //private readonly IPackageService _packageService;

    public class DependencyTrack : ApiController
    {
        

        public Uri GetDownloadUri(string packageID, string version)
        {
            //Connect to the official package repository 
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");
            DependencyTrack dependencyTrack = new DependencyTrack();
            //Get the list of all NuGet packages with ID 'EntityFramework' 
            List<IPackage> packages = repo.FindPackagesById(packageID).ToList();
            IPackage packageGet = null;
            if(packages.Count > 0)
            {
                if (version != null && version.Trim()  == "")
                {
                    SemanticVersion semanticVersion = new SemanticVersion(version);
                    packageGet = dependencyTrack.FindPackageByVersion(packages, semanticVersion);
                }
                else
                {
                    packageGet = dependencyTrack.FindPackageByVersion(packages, null);
                }

                //Filter the list of packages that are not Release (Stable) versions 
                DataServicePackage dsPackage = (DataServicePackage)packageGet;
                return dsPackage.DownloadUrl;
            }
            else
            {
                return null;
            }
        }
        public IPackage FindPackageByVersion(List<IPackage> packages, SemanticVersion sematicVersion)
        {
            //TÌm package theo version
            if(sematicVersion != null)
            {
                foreach (IPackage p in packages)
                {
                    if (p.Version.Equals(sematicVersion))
                    {
                        return p;
                    }
                }
            }

            //Lấy package lastest
            foreach (IPackage p in packages)
            {
                if (p.IsLatestVersion)
                {
                    return p;
                }
            }

            return packages.Last();
        }

        public IEnumerable<PackageDependencySet> GetDependencySet(string packageID, string version)
        {
            //Connect to the official package repository 
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");
            DependencyTrack dependencyTrack = new DependencyTrack();
            //Get the list of all NuGet packages with ID 'EntityFramework' 
            List<IPackage> packages = repo.FindPackagesById(packageID).ToList();
            IPackage packageGet = null;
            if (packages.Count > 0)
            {
                if (version != null && version.Trim() != "")
                {
                    SemanticVersion semanticVersion = new SemanticVersion(version);
                    packageGet = dependencyTrack.FindPackageByVersion(packages, semanticVersion);
                }
                else
                {
                    packageGet = dependencyTrack.FindPackageByVersion(packages, null);
                }

                //Filter the list of packages that are not Release (Stable) versions 
                DataServicePackage dsPackage = (DataServicePackage)packageGet;
                return dsPackage.DependencySets;
            }
            else
            {
                return null;
            }
        }

        public PackageToDownload ModelSeparateStringIdAndVersion(string idAndVersion)
        {
            string[] SplitString = idAndVersion.Split(' ');
            PackageToDownload packageInfo = new PackageToDownload();
            packageInfo.PackageToDownloadId = SplitString[0];
            packageInfo.PackageToDownloadVersion = SplitString[1];
            return packageInfo;
        }

        public string DownloadDependencies()
        {
            List<string> listError = new List<string>();


            return "";
        }

        public void DownloadDependency()
        {
            //string id = "Autofac.WebApi2";
            //IPackageService packageService;
            //PackageRegistration packageRegistration = packageService.FindPackageRegistrationById(id);
            
            //return true;
        } 
    }
}