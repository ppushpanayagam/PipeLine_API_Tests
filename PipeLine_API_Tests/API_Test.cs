using System.Text.Json;
using RestSharp;

namespace PipeLine_API_Tests;

public class Tests
{
    private RestClient _client;
    private RestRequest _request;
    private RestResponse _response;
    
    [SetUp]
    public void Setup()
    {
        _client = new RestClient();
        _request = new RestRequest();
        _response = new RestResponse();
    }

    [Test]
    public void Post_Request_Test()
    {
        var jsonObject = new Post_Request()
        {
            name = "raj",
            job = "IT"
        };

        _request.Resource = "https://reqres.in/api/users";
        string jsonBody = JsonSerializer.Serialize(jsonObject);
        _request.AddHeader("Content-Type", ContentType.Json);
        _request.AddJsonBody(jsonBody);

        _response = _client.Post(_request);
        Console.WriteLine(_response.Content);

        Post_Request response = JsonSerializer.Deserialize<Post_Request>(_response.Content);
        Console.WriteLine(response.name);
        Console.WriteLine(response.job);
    }
}