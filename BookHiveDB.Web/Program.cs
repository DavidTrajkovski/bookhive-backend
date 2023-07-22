using BookHiveDB.Domain;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Repository;
using BookHiveDB.Repository.Implementation;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Repository.Startup;
using BookHiveDB.Service.Implementation;
using BookHiveDB.Service.Interface;
using BookHiveDB.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<BookHiveApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

var emailService = new EmailSettings();
builder.Configuration.GetSection("EmailSettings").Bind(emailService);
builder.Services.AddScoped<EmailSettings>(es => emailService);
builder.Services.AddScoped<IEmailService, EmailService>(email => new EmailService(emailService));
builder.Services.AddScoped<IBackgroundEmailSender, BackgroundEmailSender>();
builder.Services.AddHostedService<ConsumeScopedHostedService>();


builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
builder.Services.AddScoped(typeof(IBookRepository), typeof(BookRepository));
builder.Services.AddScoped(typeof(IBookShopRepository), typeof(BookShopRepository));
builder.Services.AddScoped(typeof(IUserBookRepository), typeof(UserBookRepository));
builder.Services.AddScoped(typeof(IAuthorRepository), typeof(AuthorRepository));
builder.Services.AddScoped(typeof(IBookClubRepository), typeof(BookClubRepository));
builder.Services.AddScoped(typeof(IInvitationRepository), typeof(InvitationRepository));
builder.Services.AddScoped(typeof(IPostRepository), typeof(PostRepository));
builder.Services.AddScoped(typeof(ITopicRepository), typeof(TopicRepository));
builder.Services.AddScoped(typeof(IUserInBookClubRepository), typeof(UserInBookClubRepository));
builder.Services.AddScoped(typeof(IBookInWishListRepository), typeof(BookInWishListRepository));
builder.Services.AddScoped<IGenreInitializer, GenreInitializer>();

builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookShopService, BookShopService>();
builder.Services.AddTransient<IUserBookService, UserBookService>();
builder.Services.AddTransient<IBookClubService, BookClubService>();
builder.Services.AddTransient<IInvitationService, InvitationService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<ITopicService, TopicService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBookInWishListService, BookInWishListService>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var genreInitializer = scope.ServiceProvider.GetService<IGenreInitializer>();
    genreInitializer.Seed().Wait();
}

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe")["SecretKey"];

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();

app.Run();
