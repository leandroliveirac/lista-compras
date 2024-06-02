using ListaCompras.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "pt-BR", "en-US" };
    options.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});

builder.Services.AddApiConfiguration(builder.Configuration);

var app = builder.Build();


app.UseApiConfiguration(app.Environment);

app.Run();
