using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NuGet;

namespace NuGetGallery.Services
{
    public class DependencyTrack
    {
        public Uri GetDownloadUri(string packageID, string version)
        {
            //Connect to the official package repository 
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");
            DependencyTrack dependencyTrack = new DependencyTrack();
            //Get the list of all NuGet packages with ID 'EntityFramework' 
            List<IPackage> packages = repo.FindPackagesById(packageID).ToList();
            IPackage packageGet = null;
            if (version != null && version.Trim().Length != 0)
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

        public void GetDependency(PackageDependencySet packageDependencySet)
        {
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");
            List<IPackage> packages = null;
            DependencyTrack dependencyTrack = new DependencyTrack();
            foreach (PackageDependency p in packageDependencySet.Dependencies)
            {
                string id = p.Id;
                IVersionSpec versionSpec = p.VersionSpec;
                SemanticVersion version = new SemanticVersion(versionSpec.ToString());
                packages = repo.FindPackagesById(id).ToList();
                IPackage package = FindPackageByVersion(packages, version);
                DataServicePackage dspk = (DataServicePackage)package;
                Uri downloadUrl = new Uri(dspk.DownloadUrl.AbsoluteUri);
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
    }
}