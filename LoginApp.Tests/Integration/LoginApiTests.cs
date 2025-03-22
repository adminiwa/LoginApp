
using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace LoginApp.Tests.Integration;

[TestFixture]
public class LoginApiTests
{
    private readonly string _endpointUrl = "https://app.agrodexsas.com/ApiApp/AgrdxApi.php";
    private HttpClient _httpClient = null!;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
    }

    [Test]
    public async Task LoginEndpoint_ReturnsSuccessMessage_WhenCredentialsAreValid()
    {
        var payload = new
        {
            method = "LOGIN",
            usuario = "lbuiles",
            password = "lbuiles87*"
        };

        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(_endpointUrl, content);
        var responseContent = await response.Content.ReadAsStringAsync();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(responseContent, Does.Contain("Inicio de sesion exitoso"));
    }

    [TearDown]
    public void Cleanup()
    {
        _httpClient?.Dispose();
    }
}
