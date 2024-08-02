using Contact.API.Infrastructure;
using Contact.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//AddScoped her HTTP isteði için bir kez oluþturulur ve istek süresince ayný nesne kullanýlýr.
//AddTransient  baðýmlýlýklar her talep edildiðinde yeni bir örnek olarak yaratýlýr.
//AddSingleton uygulama boyunca tek bir nesne örneði oluþturur. Bu, uygulama ömrü boyunca ayný nesne örneðinin kullanýldýðý anlamýna gelir
/*
Scoped: Genellikle, veritabaný baðlamlarý (DbContext gibi) gibi istek baþýna baðýmlýlýklar için kullanýlýr.
Transient: Hafif ve durumsuz (stateless) baðýmlýlýklar için uygundur. Yüksek maliyetli oluþturma operasyonlarý gerektiren sýnýflar için dikkatli kullanýlmalýdýr.
Singleton: Neredeyse hiç deðiþmeyen, tüm uygulama boyunca ayný kalan ve paylaþýlmasý gereken baðýmlýlýklar için uygundur. Ancak, thread-safe olmalarý önemlidir çünkü ayný örnek birden fazla thread tarafýndan kullanýlabilir.
 */
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://*:9000");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
