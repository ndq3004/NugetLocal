// <auto-generated />
namespace NuGetGallery.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    public sealed partial class UniquePackageRegistration : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(UniquePackageRegistration));
        
        string IMigrationMetadata.Id
        {
            get { return "201505261416326_UniquePackageRegistration"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
