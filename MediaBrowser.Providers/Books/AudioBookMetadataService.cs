using MediaBrowser.Controller.Configuration;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.IO;
using MediaBrowser.Providers.Manager;
using Microsoft.Extensions.Logging;

namespace MediaBrowser.Providers.Books
{
    public class AudioBookMetadataService : MetadataService<AudioBook, SongInfo>
    {
        protected override void MergeData(MetadataResult<AudioBook> source, MetadataResult<AudioBook> target, MetadataFields[] lockedFields, bool replaceData, bool mergeMetadataSettings)
        {
            ProviderUtils.MergeBaseItemData(source, target, lockedFields, replaceData, mergeMetadataSettings);

            var sourceItem = source.Item;
            var targetItem = target.Item;

            if (replaceData || targetItem.Artists.Length == 0)
            {
                targetItem.Artists = sourceItem.Artists;
            }

            if (replaceData || string.IsNullOrEmpty(targetItem.Album))
            {
                targetItem.Album = sourceItem.Album;
            }
        }

        public AudioBookMetadataService(IServerConfigurationManager serverConfigurationManager, ILogger logger, IProviderManager providerManager, IFileSystem fileSystem, IUserDataManager userDataManager, ILibraryManager libraryManager) : base(serverConfigurationManager, logger, providerManager, fileSystem, userDataManager, libraryManager)
        {
        }
    }
}
