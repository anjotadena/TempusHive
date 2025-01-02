using TempusHive.Api.Extensions;
using TempusHive.Common.Application;
using TempusHive.Modules.Occasions.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

builder.Services.AddApplication([TempusHive.Modules.Occasions.Application.AssemblyReference.Assembly]);

builder.Services.AddOccasionsModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

OccasionsModule.MapEndpoints(app);

await app.RunAsync();
