using LibrarySystem.Core.Common;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using LibrarySystem.Infra.Common;
using LibrarySystem.Infra.Repository;
using LibrarySystem.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// Create a new instance of a web application using provided arguments
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add controllers to handle incoming HTTP requests
builder.Services.AddControllers();

// Add API explorer to generate API documentation (Swagger/OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add scoped services to the dependency injection container

// Register the DbContext interface and implementation
builder.Services.AddScoped<IDbContext, DbContext>();

// Register BookReview-related interfaces and implementations
builder.Services.AddScoped<IBookReviewRepository, BookReviewRepository>();
builder.Services.AddScoped<IBookReviewService, BookReviewService>();

// Register BorrowedBook-related interfaces and implementations
builder.Services.AddScoped<IBorrowedBookRepository, BorrowedBookRepository>();
builder.Services.AddScoped<IBorrowedBookService, BorrowedBookService>();

 // Register Homepage-related interfaces and implementations
builder.Services.AddScoped<IHomepageRepository, HomepageRepository>();
builder.Services.AddScoped<IHomepageService, HomepageService>();

// Register ContactUsPage-related interfaces and implementations
builder.Services.AddScoped<IContactUsPageRepository, ContactUsPageRepository>();
builder.Services.AddScoped<IContactUsPageService, ContactUsPageService>();

// Register AboutUsPage-related interfaces and implementations
builder.Services.AddScoped<IAboutUsPageRepository, AboutUsPageRepository>();
builder.Services.AddScoped<IAboutUsPageService, AboutUsPageService>();

// Register JWT-related interfaces and implementations
builder.Services.AddScoped<IJWTRepository, JWTRepository>();
builder.Services.AddScoped<IJWTService, JWTService>();

// Register Bank-related interfaces and implementations
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IBankService, BankService>();

// Register Contactus-related interfaces and implementations
builder.Services.AddScoped<IContactusRepository, ContactusRepository>();
builder.Services.AddScoped<IContactusService, ContactusService>();

// Register TestimonialPage-related interfaces and implementations
builder.Services.AddScoped<ITestimonialPageRepository, TestimonialPageRepository>();
builder.Services.AddScoped<ITestimonialPageService, TestimonialPageService>();

// Register Library-related interfaces and implementations
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<ILibraryService, LibraryService>();

// Register Category-related interfaces and implementations
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Register Book-related interfaces and implementations
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

// Register Role-related interfaces and implementations
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

// Register User-related interfaces and implementations
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Register Testimonial-related interfaces and implementations
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();

// Configure JWT authentication
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

builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("policy",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.

// If the application is in development mode
if (app.Environment.IsDevelopment())
{
    // Enable Swagger/OpenAPI documentation
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable authorization
app.UseAuthorization();

// Use authentication middleware
app.UseAuthentication();

// Use CORS
app.UseCors("policy");

// Map incoming HTTP requests to controllers
app.MapControllers();

// Run the application
app.Run();
