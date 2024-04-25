using Com.DevEficiente.CasaDoCodigo.Aplication.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<NotificationFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add MediatR with the assembly containing your request handlers
builder.Services.AddMediatR(typeof(Program).Assembly);
NativeInjectorBootStrapper.CasaDoCodigoRegisterMongoDBServices(builder.Services);
NativeInjectorBootStrapper.CasaDoCodigoRegisterMediatR(builder.Services);
NativeInjectorBootStrapper.CasaDoCodigoRegisterBuilder(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();