using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StatusCode;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var chave = Encoding.ASCII.GetBytes(Ambiente.Chave);

builder.Services
    .AddAuthentication(y =>
    {
        y.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        y.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(y =>
    {
        y.RequireHttpsMetadata = false;
        y.SaveToken = true;
        y.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(chave),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
