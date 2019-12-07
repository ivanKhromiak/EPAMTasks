using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OneDriveManipulation
{
    public class Operations
    {
        public static async Task<Stream> GetFile()
        {
            IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder
                        .Create("5cd44a93-b9bd-48cf-b99b-772cd08aa0e0")
                        .WithRedirectUri("http://localhost")
                        .Build();

            var authProvider = new InteractiveAuthenticationProvider(publicClientApplication, new[] { "Files.read" });

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var stream = await graphClient.Me.Drive.Items["9694446503212449!333"].Content
                .Request()
                .GetAsync();

            return stream;
        }
    }
}
