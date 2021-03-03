using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web.Resource;
using RMotownFestival.Api.Common;
using System.Linq;
using System.Threading.Tasks;

namespace RMotownFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        static readonly string[] ScopesRequiredByApiToUploadPictures = new string[] { "Pictures.Upload.All" };

        public BlobUtility BlobUtility { get; }

        private readonly IConfiguration Configuration;

        public PicturesController(BlobUtility blobUtility, IConfiguration configuration)
        {
            BlobUtility = blobUtility;
            Configuration = configuration;
        }

        [HttpGet]
        public string[] GetAllPictureUrls()
        {
            BlobContainerClient container = BlobUtility.GetThumbsContainer();

            return container.GetBlobs()
                            .Select(blob => BlobUtility.GetSasUri(container, blob.Name))
                            .ToArray();
        }

        [HttpPost]
        [Authorize]
        public async Task PostPictureAsync(IFormFile file)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(ScopesRequiredByApiToUploadPictures);

            BlobContainerClient container = BlobUtility.GetPicturesContainer();
            container.UploadBlob(file.FileName, file.OpenReadStream());

            var messagingConfiguration = Configuration.GetSection("Messaging");
            await using (ServiceBusClient client = new ServiceBusClient(messagingConfiguration.GetValue<string>("ConnectionString")))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(messagingConfiguration.GetValue<string>("QueueName"));

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage($"The picture {file.FileName} was uploaded! Send a fictional mail to me@you.us");

                // send the message
                await sender.SendMessageAsync(message);
            }
        }
    }
}
