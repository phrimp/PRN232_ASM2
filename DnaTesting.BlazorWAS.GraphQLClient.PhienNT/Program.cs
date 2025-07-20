using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DnaTesting.BlazorWAS.GraphQLClient.PhienNT;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using DnaTesting.BlazorWAS.GraphQLClient.PhienNT.GraphQLClient;
using DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DnaTestService>();


builder.Services.AddScoped<IGraphQLClient>(c => new GraphQLHttpClient("http://localhost:5081/graphql", new NewtonsoftJsonSerializer()));
builder.Services.AddScoped                                                                                                                                                                                                                                                                                                                                                                                                                              < GraphQLConsumer>();

 await builder.Build().RunAsync();
