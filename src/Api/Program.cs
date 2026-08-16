using Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// TODO: Complete OpenApi setup to be compliant with RFC 9457.
builder.Services.AddOpenApi();
builder.Services.AddApiServices();

var app = builder.Build();
//TODO: Add logger middleware, non-sensitive data, limits, etc...
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(pattern: Constants.OpenApiDocumentRoute); 
    app.UseSwaggerUI(setupAction: (options) => options.SwaggerEndpoint(url: Constants.OpenApiDocumentRoute, name: Constants.OpenApiDocumentName));
}
else
{
    app.UseHttpsRedirection(); //TODO: Do we need in isolated dev environment.
    app.UseExceptionHandler(errorHandlingPath: "/error"); //TODO: Not a dev env dependency, add later...
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
