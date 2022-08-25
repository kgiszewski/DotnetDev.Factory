using DotnetDev.Factory.Api.CreditCard;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<StripeProvider>(); //concrete
builder.Services.AddScoped<CloverProvider>(); //concrete
builder.Services.AddScoped<ICreditCardFactory>(x =>
{
    //instantiate with a func delegate
    return new CreditCardFactory(providerId =>
    {
        switch (providerId)
        {
            case 1:
                return x.GetRequiredService<StripeProvider>();
            case 2:
                return x.GetRequiredService<CloverProvider>();
        }

        throw new NotImplementedException();
    });
});

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