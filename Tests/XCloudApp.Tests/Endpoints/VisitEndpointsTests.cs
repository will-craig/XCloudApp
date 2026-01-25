using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using XCloudApp.Domain.Entities;
using XCloudApp.Domain.Enum;
using XCloudApp.Tests.Infrastructure;
using Xunit;

namespace XCloudApp.Tests.Endpoints;

public class VisitEndpointsTests : IClassFixture<ApiFactory>
{
    private readonly ApiFactory _factory;

    public VisitEndpointsTests(ApiFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Healthz_returns_ok()
    {
        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/healthz");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Post_visit_creates_visit_and_is_returned_by_get()
    {
        using var client = _factory.CreateClient();

        var postResponse = await client.PostAsync("/visit", content: null);
        Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);

        var created = await postResponse.Content.ReadFromJsonAsync<Visit>();
        Assert.NotNull(created);
        Assert.True(created!.Id > 0);
        Assert.Equal(CSP.AmazonWebServices, created.CloudServiceProvider);

        var getResponse = await client.GetAsync("/visit");
        Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

        var visits = await getResponse.Content.ReadFromJsonAsync<List<Visit>>();
        Assert.NotNull(visits);
        Assert.Contains(visits!, visit => visit.Id == created.Id && visit.CloudServiceProvider == created.CloudServiceProvider);
    }
}
