using Reservation.API.Infrastructure;
using Reservation.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//AddScoped her HTTP iste�i i�in bir kez olu�turulur ve istek s�resince ayn� nesne kullan�l�r.
//AddTransient  ba��ml�l�klar her talep edildi�inde yeni bir �rnek olarak yarat�l�r.
//AddSingleton uygulama boyunca tek bir nesne �rne�i olu�turur. Bu, uygulama �mr� boyunca ayn� nesne �rne�inin kullan�ld��� anlam�na gelir
/*
Scoped: Genellikle, veritaban� ba�lamlar� (DbContext gibi) gibi istek ba��na ba��ml�l�klar i�in kullan�l�r.
Transient: Hafif ve durumsuz (stateless) ba��ml�l�klar i�in uygundur. Y�ksek maliyetli olu�turma operasyonlar� gerektiren s�n�flar i�in dikkatli kullan�lmal�d�r.
Singleton: Neredeyse hi� de�i�meyen, t�m uygulama boyunca ayn� kalan ve payla��lmas� gereken ba��ml�l�klar i�in uygundur. Ancak, thread-safe olmalar� �nemlidir ��nk� ayn� �rnek birden fazla thread taraf�ndan kullan�labilir.
 */
builder.Services.AddScoped<IReservationService, ReservationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
