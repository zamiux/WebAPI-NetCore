var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

#region Special Middleware Pipeline
// olaviate Run Mohemme

if (app.Environment.IsDevelopment()) 
{
    // active Swagger
    app.UseSwagger(); // create document by Swaggwer
    app.UseSwaggerUI(); // namayesh UI Swaggwer
}


app.UseHttpsRedirection(); // middleware redirect http to https
app.UseAuthorization(); // middleware authorize user

// ye Map baraye Routing va Dastresi be Controllers
// Ex: zamiux.com/Controller/Action/?Parameter
app.MapControllers(); // middleware Routing for Controllers



// in yani project Run shod agar har Request OOmad ke Middleware natoonest Handle kone
// bedesh be man man ba ye Text Handle konam. 

app.Run(async (context)=>
{
    await context.Response.WriteAsync("Hello User, Har Link Biad Man Mibinam :) !!");
}); 






#endregion

app.Run();
