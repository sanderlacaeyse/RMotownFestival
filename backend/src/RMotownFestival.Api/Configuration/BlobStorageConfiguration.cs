using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RMotownFestival.Api.Common;
using RMotownFestival.Api.Options;

namespace RMotownFestival.Api
{
    public static class BlobStorageConfiguration
    {
        public static void AddBlobStorageClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BlobSettingsOptions>(configuration.GetSection("Storage"));

            services.AddSingleton(p => new StorageSharedKeyCredential(
                configuration.GetValue<string>("Storage:AccountName"),
                configuration.GetValue<string>("Storage:AccountKey")));

            services.AddSingleton(p => new BlobServiceClient(configuration.GetValue<string>("Storage:ConnectionString")));

            services.AddSingleton<BlobUtility>();
        }
    }
}
