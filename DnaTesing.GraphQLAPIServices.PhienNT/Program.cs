using DnaTesing.GraphQLAPIServices.PhienNT.GraphQLs;
using DNATesting.Service.PhienNT;
using DNATesting.Services.PhienNT;
using System.Text.Json.Serialization;
using IServiceProvider = DNATesting.Service.PhienNT.IServiceProvider;
using ServiceProvider = DNATesting.Service.PhienNT.ServiceProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>().BindRuntimeType<DateTime, DateTimeType>().ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);
builder.Services.AddScoped<IServiceProvider, ServiceProvider>();
builder.Services.AddScoped<IDnaTestsPhienNtService, DnaTestsPhienNtService>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", builder =>
    {
        builder
            .WithOrigins("http://localhost:5038") // Blazor client URL
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowBlazorClient");

app.UseAuthorization();

app.MapControllers();

app.UseRouting().UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
