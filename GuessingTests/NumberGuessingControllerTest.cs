using Guessing;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace GuessingTests
{
    public class NumberGuessingControllerTest
    {
        [Test]
        public async Task GuidChecker()
        {
            using var app = new WebApplicationFactory<Startup>();

            using var client = app.CreateClient();

            var response = await client.GetAsync("NumberGuessing/start");

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            var result = await Deserialize<Guid>(response.Content);

            Assert.NotNull(result);
        }

        private static async Task<T> Deserialize<T>(HttpContent content)
        {
            var contentStream = await content.ReadAsStreamAsync();

            using var streamnreader = new StreamReader(contentStream);

            using var jsonreader = new JsonTextReader(streamnreader);

            JsonSerializer serializer = new JsonSerializer();

            return serializer.Deserialize<T>(jsonreader);


        }
    }
}