var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddHttpClient("LoyaltyService", client =>
{
    client.BaseAddress = new Uri("http://loyalty-service.default.svc.cluster.local:8050");
});

builder.Services.AddHttpClient("PaymentService", client =>
{
    client.BaseAddress = new Uri("http://payment-service.default.svc.cluster.local:8060");
});

builder.Services.AddHttpClient("ReservationService", client =>
{
    client.BaseAddress = new Uri("http://reservation-service.default.svc.cluster.local:8070");
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();

app.Run();
