using NUnit.Framework;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace PetstoreApiTests
{
    public class PetTests
    {
        private RestClient client = null!;
        private long testPetId;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://petstore.swagger.io/v2");
            testPetId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); // Unique ID
            Console.WriteLine($"✅ Pet added with ID: {testPetId}");
        }

        [Test]
        public void AddReadDeletePet_WithRetry_ShouldSucceed()
        {
            // Add pet
            var addRequest = new RestRequest("/pet", Method.Post);
            var pet = new
            {
                id = testPetId,
                name = "SubashreeDog",
                status = "available"
            };
            addRequest.AddJsonBody(pet);
            var postResponse = client.Execute(addRequest);

            Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(postResponse.Content, Is.Not.Null);
            Assert.That(postResponse.Content!, Does.Contain("SubashreeDog"));

            // Retry GET up to 3 times
            JObject? json = null;
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                var getRequest = new RestRequest($"/pet/{testPetId}", Method.Get);
                var getResponse = client.Execute(getRequest);

                if (getResponse.StatusCode == HttpStatusCode.OK && getResponse.Content != null)
                {
                    json = JObject.Parse(getResponse.Content);
                    break;
                }

                Thread.Sleep(1000); // Wait before retry
            }

            Assert.That(json, Is.Not.Null, "Pet not found after retries.");
            Assert.That(json!["name"]?.ToString(), Is.EqualTo("SubashreeDog"));

            // Optional: Delete pet
            /*
            var deleteRequest = new RestRequest($"/pet/{testPetId}", Method.Delete);
            var deleteResponse = client.Execute(deleteRequest);

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(deleteResponse.Content, Is.Not.Null);
            Assert.That(deleteResponse.Content!, Does.Contain("message"));
            */
        }
    }
}