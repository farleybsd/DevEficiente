using br.com.deveficiente.mercadolivre.Application.Filters;
using br.com.deveficiente.mercadolivre.Infra.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<NotificationFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

NativeInjectorBootStrapper.mercadolivreRegisterSqslDBServices(builder.Services, builder.Configuration);
NativeInjectorBootStrapper.CasaDoCodigoRegisterMediatR(builder.Services);
NativeInjectorBootStrapper.mercadolivreRegisterBuilder(builder.Services);

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