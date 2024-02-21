using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

#region add return xml type in api
// add return xml type in api 
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();

#endregion


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Format Type File Automate
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
#endregion

var app = builder.Build();

#region Special Middleware Pipeline
// olaviate Run Mohemme

if (app.Environment.IsDevelopment()) 
{
    // active Swagger
    app.UseSwagger(); // create document by Swaggwer
    app.UseSwaggerUI(); // namayesh UI Swaggwer
}


app.UseHttpsRedirection(); // middleware redirect http to https
    
app.UseRouting(); // use routing

app.UseAuthorization(); // middleware authorize user

// ye Map baraye Routing va Dastresi be Controllers
// Ex: zamiux.com/Controller/Action/?Parameter
//
//app.MapControllers(); // middleware Routing for Controllers

// Define Route: /Controller/Action/?Parameter
app.UseEndpoints(endpoints => { 
    endpoints.MapControllers(); 
});


// in yani project Run shod agar har Request OOmad ke Middleware natoonest Handle kone
// bedesh be man man ba ye Text Handle konam. 
app.Run(async (context)=>
{
    await context.Response.WriteAsync("Hello User, Har Link Biad Man Mibinam :) !!");
}); 






#endregion

app.Run();
