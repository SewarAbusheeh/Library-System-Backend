using LibrarySystem.Core.Common;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using LibrarySystem.Infra.Common;
using LibrarySystem.Infra.Repository;
using LibrarySystem.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbContext, DbContext>();

builder.Services.AddScoped<IBookReviewRepository, BookReviewRepository>();
builder.Services.AddScoped<IBookReviewService, BookReviewService>();

builder.Services.AddScoped<IBorrowedBookRepository, BorrowedBookRepository>();
builder.Services.AddScoped<IBorrowedBookService, BorrowedBookService>();
builder.Services.AddScoped<IHomepageRepository, HomepageRepository>();
builder.Services.AddScoped<IHomepageService, HomepageService>();
builder.Services.AddScoped<IContactUsPageRepository, ContactUsPageRepository>();
builder.Services.AddScoped<IContactUsPageService, ContactUsPageService>();
builder.Services.AddScoped<IAboutUsPageRepository, AboutUsPageRepository>();
builder.Services.AddScoped<IAboutUsPageService, AboutUsPageService>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
    };
});

builder.Services.AddScoped<IJWTRepository, JWTRepository>();
builder.Services.AddScoped<IJWTService, JWTService>();
//bank
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IBankService, BankService>();
//Contactus
builder.Services.AddScoped<IContactusRepository, ContactusRepository>();
builder.Services.AddScoped<IContactusService, ContactusService>();
//testimonialpage 
builder.Services.AddScoped<ITestimonialPageRepository, TestimonialPageRepository>();
builder.Services.AddScoped<ITestimonialPageService, TestimonialPageService>();

builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<ILibraryService, LibraryService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
