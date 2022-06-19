using NUnit.Framework;
using RestSharp;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TestAPIFW
{
    public class APITests
    {
        public Logger logger;

        [SetUp]
        public void Setup()
        {
            logger = new Logger();
        }

        [Test]
        [Ignore("Not An Actual Test")]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void StatusCodeTest()
        {
            logger.InitializeLogger(TestContext.CurrentContext.Test.Name);

            string uri= "https://jsonplaceholder.typicode.com/posts/1";
            // arrange

            var client = new RestClient(uri);
            logger.LogStepInfo(Logger.MessageType.Info, "Client Has Been Initialized");

            //Create Request
            var request = new RestRequest();

            //request.AddFile()

            //execute request
            var result = client.GetAsync(request);
            logger.LogStepInfo(Logger.MessageType.Info, "Client Has Been Executed And Result has come");

            //check result data
            var data = result.Result.Content;

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(data)))
            {
                // Deserialization from JSON
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(JsonToCSharpSchema.BasicUserDetails));
                JsonToCSharpSchema.BasicUserDetails basicUserDetails = (JsonToCSharpSchema.BasicUserDetails)deserializer.ReadObject(ms);
                var userid = basicUserDetails.id;
                var userTitle = basicUserDetails.title;

                Assert.AreEqual(userid,"", "Userid does not match");
                //Assert.NotNull(userTitle);
                
                logger.LogStepInfo(Logger.MessageType.Info, "Validation Success");
            }

            client.Dispose();
            logger.DisposeLogger();
        }

        [Test]
        [Ignore("To Be Enable Later")]
        public void AuthToken()
        {
            var client = new RestClient("https://api.soundcloud.com");
            const string clientSecret = "";
            var request = new RestRequest("oauth2/token");
            string encodedBody = string.Format("");
            request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
            request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);
            var response = client.PostAsync(request);
            var Token = response.Result.Content[0];

        }
    }
}