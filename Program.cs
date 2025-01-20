using Microsoft.EntityFrameworkCore;
using Suivi_Colis_Back.Data;
using Suivi_Colis_Back.Mappers;
using Suivi_Colis_Back.Repositories;
using Suivi_Colis_Back.Services;
using static Suivi_Colis_Back.Services.PdfService;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services au conteneur
builder.Services.AddControllers();

// Configurer Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurer la base de données PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("bdd")));

// Ajouter les services Scoped
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserMapper, UserMapper>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderMapper, OrderMapper>();

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>(); 
builder.Services.AddScoped<IInvoiceMapper, InvoiceMapper>();
builder.Services.AddScoped<IPdfService, PdfService>();
//builder.Services.AddScoped<IInvoiceService, InvoiceService>(); 

// Ajouter les services nécessaires pour les sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});

// Configurer CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configurer le pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseSession();
app.UseAuthorization();

app.MapControllers();
app.Run();
