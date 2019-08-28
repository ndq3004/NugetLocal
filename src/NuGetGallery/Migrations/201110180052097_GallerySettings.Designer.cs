using System.Data.Entity.Migrations.Infrastructure;

namespace NuGetGallery.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class GallerySettings : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201110180052097_GallerySettings"; }
        }

        string IMigrationMetadata.Source
        {
            get { return null; }
        }

        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}
