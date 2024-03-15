using CodeCampRestora.Application;
using CodeCampRestora.Api.Settings;
using CodeCampRestora.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApi()
    .AddSwagger()
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors();
app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.MapControllers();

app.Run();
