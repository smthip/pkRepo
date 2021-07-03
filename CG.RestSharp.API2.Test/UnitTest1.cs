using NUnit.Framework;
using RestSharp;

namespace CG.RestSharp.API2.Test
{
    public class Tests
    {
        private string baseURL;
        [SetUp]
        public void Setup()
        {

             baseURL = "https://jsonplaceholder.typicode.com/posts/";
            
           
        }

        [Test]
        public void getResource()
        {
            var client = new RestClient(baseURL);
            var request = new RestRequest();

            request.AddParameter("id", "1");
            var response = client.Get(request);
            System.Console.WriteLine(response.Content.ToString());
        }

        [Test]
        public void postResource()
        {

            var client = new RestClient(baseURL);
            var request = new RestRequest();

           
            var body = new post{ body = "This is the test body", title = "test post request", userId = 777 };

            request.AddJsonBody(body);

            var response = client.Post(request);
            System.Console.WriteLine(response.StatusCode.ToString() +  "  "+ response.Content.ToString());

        }

     }
}